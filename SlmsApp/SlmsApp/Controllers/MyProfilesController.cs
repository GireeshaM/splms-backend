using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.ProfileService;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyProfilesController : ControllerBase
    {
        private readonly IMyProfileService _service;

        public MyProfilesController(IMyProfileService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var profile = await _service.GetProfileByUserIdAsync(userId);
            // Instead of returning NotFound (404), return Ok with null or empty profile
            if (profile == null)
                return Ok(null);  // Return 200 OK with null body

            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] MyProfileDto profileDto)
        {
            try
            {
                await _service.CreateOrUpdateProfileAsync(profileDto);
                return Ok(new { message = "Profile saved successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
