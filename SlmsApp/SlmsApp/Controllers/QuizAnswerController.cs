using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.QuizService;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAnswerController : ControllerBase
    {
        private readonly IQuizAnswerService _quizAnswerService;

        public QuizAnswerController(IQuizAnswerService quizAnswerService)
        {
            _quizAnswerService = quizAnswerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuizAnswerDto>>> GetAll()
        {
            var quizAnswers = await _quizAnswerService.GetAllQuizAnswersAsync();
            return Ok(quizAnswers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizAnswerDto>> GetById(int id)
        {
            var quizAnswer = await _quizAnswerService.GetQuizAnswerByIdAsync(id);
            if (quizAnswer == null)
            {
                return NotFound();
            }
            return Ok(quizAnswer);
        }

        [HttpGet("question/{questionId}")]
        public async Task<ActionResult<List<QuizAnswerDto>>> GetAnswersByQuestionId(int questionId)
        {
            Console.WriteLine($"GetAnswersByQuestionId called with questionId: {questionId}");
            var answers = await _quizAnswerService.GetAnswersByQuestionIdAsync(questionId);
            return Ok(answers);
        }

        [HttpPost("save")]
        public async Task<ActionResult<QuizAnswerDto>> Save(QuizAnswerDto quizAnswerDto)
        {
            if (quizAnswerDto.QuizAnswerId == 0)
            {
                // Create
                var created = await _quizAnswerService.AddQuizAnswerAsync(quizAnswerDto);
                return CreatedAtAction(nameof(GetById), new { id = created.QuizAnswerId }, created);
            }
            else
            {
                // Update
                var updated = await _quizAnswerService.UpdateQuizAnswerAsync(quizAnswerDto);
                return Ok(updated);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _quizAnswerService.DeleteQuizAnswerAsync(id);
            return NoContent();
        }
    }
}
