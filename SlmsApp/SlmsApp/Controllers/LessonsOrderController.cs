using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.LessonsOrderServices;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsOrderController : ControllerBase
    {
        private readonly ILessonsOrderService _service;

        public LessonsOrderController(ILessonsOrderService service)
        {
            _service = service;
        }

      
        [HttpPost("saveOrUpdate")]
        public async Task<IActionResult> SaveOrUpdate([FromBody] List<LessonsOrderDto> orders)
        {
            if (orders == null || orders.Count == 0)
                return BadRequest("Orders list cannot be empty.");

            try
            {
                await _service.SaveOrUpdateOrdersAsync(orders);
                return Ok("Saved or Updated successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get OrderId by VideoId.
        /// </summary>
        /// <param name="videoId">Video ID</param>
        /// <returns>OrderId</returns>
        [HttpGet("getOrderIdByVideoId/{videoId}")]
        public async Task<IActionResult> GetOrderIdByVideoId(int videoId)
        {
            var orderId = await _service.GetOrderIdByVideoIdAsync(videoId);
            if (orderId == null)
                return NotFound("Video not found.");

            return Ok(orderId);
        }

        /// <summary>
        /// Get OrderId by QuizId.
        /// </summary>
        /// <param name="quizId">Quiz ID</param>
        /// <returns>OrderId</returns>
        [HttpGet("getOrderIdByQuizId/{quizId}")]
        public async Task<IActionResult> GetOrderIdByQuizId(int quizId)
        {
            var orderId = await _service.GetOrderIdByQuizIdAsync(quizId);
            if (orderId == null)
                return NotFound("Quiz not found.");

            return Ok(orderId);
        }
    }
}