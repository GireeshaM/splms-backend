using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsApp.ViewModels;
using SlmsAppBusiness.CoursesServices;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        // Post and Put use the same endpoint for Create and Update
      
        [HttpPost("CreateOrUpdate")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> CreateOrUpdate([FromForm] CreateCourseRequest request)
        {
            Console.WriteLine($"Incoming CourseId: {request.CreateCourseId}");
            byte[] thumbnailBytes = await ConvertToBytes(request.Thumbnail);
            byte[] demoVideoBytes = await ConvertToBytes(request.DemoVideo);

            // Handle Category ID
            int categoryId;
            if (request.CategoryId.HasValue)
            {
                categoryId = request.CategoryId.Value;
            }
            else if (!string.IsNullOrWhiteSpace(request.CategoryName))
            {
                categoryId = await _service.AddCategoryIfNotExistsAsync(request.CategoryName);
            }
            else
            {
                return BadRequest("Either CategoryId or CategoryName must be provided.");
            }

            // Handle SubCategory ID
            int subCategoryId;
            if (request.SubCategoryId.HasValue)
            {
                subCategoryId = request.SubCategoryId.Value;
            }
            else if (!string.IsNullOrWhiteSpace(request.SubCategoryName))
            {
                subCategoryId = await _service.AddSubCategoryIfNotExistsAsync(request.SubCategoryName, categoryId);
            }
            else
            {
                return BadRequest("Either SubCategoryId or SubCategoryName must be provided.");
            }

            var courseDto = new CreateCourseDto
            {
                CreateCourseId = request.CreateCourseId,
                UserId = request.UserId,
                CategoryId = categoryId,
                SubCategoryId = subCategoryId,
                CourseTitle = request.CourseTitle,
                CourseDescription = request.CourseDescription,
                Level = request.Level,
                Duration = request.Duration,
                CourseOverview = request.CourseOverview,
                PreRequirements = request.PreRequirements?.Split(',') ?? Array.Empty<string>(),
                SkillsYouGain = request.SkillsYouGain?.Split(',') ?? Array.Empty<string>(),
                WhatYouWillLearn = request.WhatYouWillLearn?.Split(',') ?? Array.Empty<string>(),
                Thumbnail = thumbnailBytes,
                DemoVideo = demoVideoBytes,
                InProgress = request.InProgress,
                CourseStatus = request.CourseStatus,
                AdminReview = request.AdminReview,
                IsUploaded = request.IsUploaded



            };

            // Create or update the course
            try
            {
                var courseId = await _service.CreateOrUpdateAsync(courseDto);
                return Ok(new { message = "Course created/updated successfully", courseId });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message, stackTrace = ex.StackTrace });
            }

        }

        private async Task<byte[]> ConvertToBytes(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }
      

        // Get course by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        // Get all courses for a specific user
        [HttpGet("ByUserId/{userId}")]
        public async Task<IActionResult> GetCoursesByUserId(int userId)
        {
            var courses = await _service.GetCoursesByUserIdAsync(userId);
            return courses != null && courses.Any() ? Ok(courses) : NotFound("No courses found for this user.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { message = "Deleted successfully" });
        }

        [HttpPatch("UpdateAdminReview/{courseId}")]
        public async Task<IActionResult> UpdateAdminReview(int courseId)
        {
            try
            {
                await _service.MarkCourseAsSentToAdminAsync(courseId);
                return NoContent(); // 204
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Course not found" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Failed to update AdminReview" });
            }
        }

        [HttpGet("UserCourseDetails")]
        public async Task<IActionResult> GetUserCourseDetails([FromQuery] int courseId, [FromQuery] int userId)
        {
            var course = await _service.FetchUserCourseDetailsAsync(courseId, userId);

            if (course == null)
                return Unauthorized(new { message = "User is not enrolled in this course." });

            return Ok(course);
        }


    }
}