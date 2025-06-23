using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.CourseEnrollmentServices;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly ICourseEnrollmentService _service;

        public CourseEnrollmentController(ICourseEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId) =>
            Ok(await _service.GetByUserIdAsync(userId));

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId) =>
            Ok(await _service.GetByCourseIdAsync(courseId));

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([FromBody] CourseEnrollmentDto dto)
        {
            // Check if the user is already enrolled in this course
            var existingEnrollments = await _service.GetByUserIdAsync(dto.UserId);
            bool alreadyEnrolled = existingEnrollments.Any(e => e.CreateCourseId == dto.CreateCourseId);

            if (alreadyEnrolled)
            {
                return Conflict("User already enrolled in this course.");
            }

            var result = await _service.AddOrUpdateAsync(dto);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok() : NotFound();
        }
    }
}