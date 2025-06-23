using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.FaqSevicees;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseFaqsController : ControllerBase
    {
        private readonly ICourseFaqService _faqService;

        public CourseFaqsController(ICourseFaqService faqService)
        {
            _faqService = faqService;
        }

        // GET: api/CourseFaqs
        [HttpGet]
        public async Task<IActionResult> GetAllFaqs()
        {
            var faqs = await _faqService.GetAllFaqsAsync();
            return Ok(faqs);
        }

        // GET: api/CourseFaqs/course/5
        [HttpGet("course/{createCourseId}")]
        public async Task<IActionResult> GetFaqsByCourseId(int createCourseId)
        {
            var faqs = await _faqService.GetFaqsByCourseIdAsync(createCourseId);
            return Ok(faqs);
        }

        // POST: api/CourseFaqs
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateFaq([FromBody] CourseFaqDto faqDto)
        {
            var result = await _faqService.AddOrUpdateFaqAsync(faqDto);
            return Ok(result);
        }

        // DELETE: api/CourseFaqs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaq(int id)
        {
            var success = await _faqService.DeleteFaqAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

}
