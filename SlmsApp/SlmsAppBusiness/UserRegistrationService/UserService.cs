using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.UserRegistration;
using SlmsAppModels;
using SlmsAppUtilities.Email;
using SlmsAppUtilities.JwtToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.UserRegistrationService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;


        public UserService(IUserRepository repo, IJwtService jwtService, IEmailService emailService)
        {
            _repo = repo;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                throw new Exception("Passwords do not match.");

            var existingUser = await _repo.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                return false;

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), 
                RolesId = dto.RolesId ?? 1,
                
                
            };

            await _repo.AddUserAsync(user);
            await _repo.SaveChangesAsync(); // Save to get the UserId

            // Add interests if provided
           

            return true;
        }


        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);
            Console.WriteLine($"User found: {user?.Email}, PasswordHash: {user?.PasswordHash}");

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                Console.WriteLine("Invalid login attempt or missing password hash.");
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Verify password using BCrypt
            var passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            Console.WriteLine($"Password valid: {passwordValid}");

            if (!passwordValid)
            {
                Console.WriteLine("Invalid password.");
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Generate JWT token after successful login
            return _jwtService.GenerateToken(user);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null)
                return false;

            await _repo.DeleteUserAsync(user);
            return await _repo.SaveChangesAsync();
        }

        public async Task<bool> SendResetCodeAsync(string email)
        {
            var user = _repo.GetByEmail(email);
            if (user == null)
                return false;

            var code = new Random().Next(100000, 999999).ToString();
            user.ResetCode = code;
            user.ResetCodeExpiration = DateTime.UtcNow.AddMinutes(15);
            _repo.Update(user);
            _repo.Save();

            await _emailService.SendEmailAsync(email, "Your Reset Code", $"Your verification code is: {code}");
            return true;
        }

        public bool VerifyResetCode(string email, string code)
        {
            var user = _repo.GetByEmail(email);
            return user != null && user.ResetCode == code && user.ResetCodeExpiration > DateTime.UtcNow;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            var user = _repo.GetByEmail(email);
            if (user == null) return false;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            user.ResetCode = null;
            user.ResetCodeExpiration = null;
            _repo.Update(user);
            _repo.Save();
            return true;
        }
    }
}
