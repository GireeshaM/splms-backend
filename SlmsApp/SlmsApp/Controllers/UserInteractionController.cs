using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.UserWishlistServices;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInteractionController : ControllerBase
    {
        private readonly IUserWishlistService _service;

        public UserInteractionController(IUserWishlistService service)
        {
            _service = service;
        }

        [HttpPost("wishlist")]
        public async Task<IActionResult> PostOrUpdateWishlist([FromBody] UserWishlistAndVisitedDto dto)
        {
            await _service.AddOrUpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("wishlist")]
        public async Task<IActionResult> DeleteWishlist([FromQuery] int userId, [FromQuery] int courseId)
        {
            await _service.DeleteWishlistAsync(userId, courseId);
            return Ok();
        }

        [HttpGet("wishlist/byuser/{userId}")]
        public async Task<IActionResult> GetWishlistByUser(int userId) =>
            Ok(await _service.GetWishlistByUserAsync(userId));

        [HttpGet("wishlist/bycourse/{courseId}")]
        public async Task<IActionResult> GetWishlistByCourse(int courseId) =>
            Ok(await _service.GetWishlistByCourseAsync(courseId));

        [HttpPost("visited")]
        public async Task<IActionResult> PostVisited([FromBody] UserWishlistAndVisitedDto dto)
        {
            await _service.AddOrUpdateAsync(dto);
            return Ok();
        }

        [HttpGet("visited/byuser/{userId}")]
        public async Task<IActionResult> GetVisitedByUser(int userId) =>
            Ok(await _service.GetVisitedByUserAsync(userId));

        [HttpGet("visited/bycourse/{courseId}")]
        public async Task<IActionResult> GetVisitedByCourse(int courseId) =>
            Ok(await _service.GetVisitedByCourseAsync(courseId));
    }
}