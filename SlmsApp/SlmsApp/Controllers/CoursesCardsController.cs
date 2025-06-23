using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.CourseCardsServices;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesCardsController : ControllerBase
    {
        private readonly ICourseCardsService _service;

        public CoursesCardsController(ICourseCardsService service)
        {
            _service = service;
        }

        [HttpGet("cards")]
        public async Task<IActionResult> GetAllCourseCards()
        {
            var result = await _service.GetAllCourseCardsAsync();
            return Ok(result);
        }

        [HttpGet("cards/user/{userId}")]
        public async Task<IActionResult> GetCourseCardsByUserId(int userId)
        {
            var result = await _service.GetCourseCardsByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet("enrolled/{userId}")]
        public async Task<IActionResult> GetEnrolledCourses(int userId)
        {
            var result = await _service.GetEnrolledCoursesAsync(userId);
            return Ok(result);
        }

        [HttpGet("wishlist/{userId}")]
        public async Task<IActionResult> GetWishlistedCourses(int userId)
        {
            var result = await _service.GetWishlistedCoursesAsync(userId);
            return Ok(result);
        }
    }
}