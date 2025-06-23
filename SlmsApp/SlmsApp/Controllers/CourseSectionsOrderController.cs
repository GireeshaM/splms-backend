 using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.LessonsOrderServices;
using SlmsAppDataAccess.Models;
using SlmsAppModels;

namespace SlmsApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CourseSectionsOrderController : ControllerBase
    {
        private readonly ICourseSectionsOrderService _service;

        public CourseSectionsOrderController(ICourseSectionsOrderService service)
        {
            _service = service;
        }

        [HttpGet("{userId:int}/{courseId:int}")]
        public async Task<IActionResult> GetSectionOrders(int userId, int courseId)
        {
            var orders = await _service.GetSectionOrdersAsync(userId, courseId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] CourseSectionsOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = new CourseSectionsOrder
            {
                UserId = dto.UserId,
                CreateCourseId = dto.CreateCourseId,
                SectionId = dto.SectionId,
                SectionOrder = dto.SectionOrder
            };

            try
            {
                await _service.CreateOrUpdateSectionOrderAsync(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok(new { message = "Success" });
        }


        [HttpPost("swap")]
        public async Task<IActionResult> SwapSectionOrders([FromBody] SwapSectionOrderDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request");

            var result = await _service.SwapSectionOrdersAsync(dto);
            if (!result)
                return NotFound("One or both sections not found");

            return Ok("Section order swapped successfully");
        }
    }
}