using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.QuizService;
using SlmsAppModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ICreateQuizService _quizService;

        public QuizController(ICreateQuizService quizService)
        {
            _quizService = quizService;
        }

        // Get all quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateQuizDto>>> GetAll()
        {
            var quizzes = await _quizService.GetAllAsync();
            return Ok(quizzes);
        }

        // Get quiz by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CreateQuizDto>> GetById(int id)
        {
            var quiz = await _quizService.GetByIdAsync(id);
            if (quiz == null)
                return NotFound();
            return Ok(quiz);
        }

        // 🔁 Use POST for both Create and Update
        [HttpPost]
        public async Task<IActionResult> Post(CreateQuizDto quizDto)
        {
            if (quizDto.SectionId <= 0)
                return BadRequest("Section ID is required.");

            if (quizDto.CreateQuizId == 0)
            {
                var result = await _quizService.AddAsync(quizDto);
                return Ok(result);
            }
            else
            {
                await _quizService.UpdateAsync(quizDto.CreateQuizId, quizDto);
                return Ok();
            }
        }


        // Get quizzes by section ID
        [HttpGet("section/{sectionId}")]
        public async Task<ActionResult<IEnumerable<CreateQuizDto>>> GetBySection(int sectionId)
        {
            var allQuizzes = await _quizService.GetAllAsync();
            var filtered = allQuizzes.Where(q => q.SectionId == sectionId).ToList();
            return Ok(filtered);
        }

        // Delete quiz
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _quizService.DeleteAsync(id);
            return NoContent();
        }
    }
}
