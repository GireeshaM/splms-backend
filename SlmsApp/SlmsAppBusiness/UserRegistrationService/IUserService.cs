using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.UserRegistrationService
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> SendResetCodeAsync(string email);
        bool VerifyResetCode(string email, string code);
        bool ResetPassword(string email, string newPassword);

    }
}
