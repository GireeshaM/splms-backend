using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.UserRegistrationService;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                // Return validation errors to the client
                return BadRequest(new { title = "One or more validation errors occurred.", errors = ModelState });
            }

            try
            {
                var result = await _userService.RegisterAsync(dto);
                if (result)
                    return Ok(new { message = "Registration successful" });
                else
                    return BadRequest(new { message = "Registration failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }






        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            try
            {
                var token = await _userService.LoginAsync(dto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            var dto = new UserRegisterDto
            {   
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber=user.PhoneNumber,
                Password=user.PasswordHash,
                ConfirmPassword=user.PasswordHash,
                RolesId=user.RolesId,
            };

            return Ok(dto);
        }


        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound("User not found or already deleted.");

            return Ok("User deleted successfully.");
        }


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            var success = await _userService.SendResetCodeAsync(dto.Email);
            if (!success)
                return NotFound("Email not found");
            return Ok("Verification code sent");
        }




        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerifyCodeDTO dto)
        {
            var valid = _userService.VerifyResetCode(dto.Email, dto.Code);
            if (!valid)
                return BadRequest(new { message = "Invalid or expired code" });

            return Ok(new { message = "Code verified" }); // ✅ Return proper JSON
        }




        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
                return BadRequest(new { message = "Passwords do not match" });

            var result = _userService.ResetPassword(dto.Email, dto.NewPassword);
            if (!result)
                return BadRequest(new { message = "Reset failed" });

            return Ok(new { message = "Password reset successfully" }); // ✅ Return JSON with a message
        }



    }
}