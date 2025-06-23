using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.QuizService;
using SlmsAppDataAccess.Models;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizQuestionsController : ControllerBase
    {
        private readonly IQuizQuestionsBusiness _quizQuestionsBusiness;
        private readonly IMapper _mapper;

        public QuizQuestionsController(IQuizQuestionsBusiness quizQuestionsBusiness, IMapper mapper)
        {
            _quizQuestionsBusiness = quizQuestionsBusiness;
            _mapper = mapper;
        }

        // GET: api/QuizQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizQuestionDTO>>> GetQuizQuestions()
        {
            var quizQuestions = await _quizQuestionsBusiness.GetAllQuizQuestionsAsync();
            return Ok(_mapper.Map<IEnumerable<QuizQuestionDTO>>(quizQuestions));
        }

        // GET: api/QuizQuestions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizQuestionDTO>> GetQuizQuestion(int id)
        {
            var quizQuestion = await _quizQuestionsBusiness.GetQuizQuestionByIdAsync(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<QuizQuestionDTO>(quizQuestion));
        }

        // GET: api/QuizQuestions/byCreateQuizId/{createQuizId}
        [HttpGet("byCreateQuizId/{createQuizId}")]
        public async Task<ActionResult<IEnumerable<QuizQuestionDTO>>> GetQuizQuestionsByCreateQuizId(int createQuizId)
        {
            var allQuestions = await _quizQuestionsBusiness.GetAllQuizQuestionsAsync();
            var filtered = allQuestions.Where(q => q.CreateQuizId == createQuizId);
            return Ok(_mapper.Map<IEnumerable<QuizQuestionDTO>>(filtered));
        }

        // POST: api/QuizQuestions
        [HttpPost]
        public async Task<IActionResult> SaveQuizQuestion([FromBody] QuizQuestionDTO quizQuestionDTO)
        {
            if (quizQuestionDTO == null || string.IsNullOrWhiteSpace(quizQuestionDTO.QuizQuestionText))
            {
                return BadRequest("Quiz Question Text cannot be empty.");
            }

            var quizQuestion = _mapper.Map<QuizQuestion>(quizQuestionDTO);

            if (quizQuestionDTO.QuizQuestionId > 0)
            {
                // Update
                var updated = await _quizQuestionsBusiness.UpdateQuizQuestionAsync(quizQuestion);
                if (!updated) return NotFound("Quiz Question not found for update.");
                return Ok("Quiz question updated successfully.");
            }
            else
            {
                // Create
                await _quizQuestionsBusiness.CreateQuizQuestionAsync(quizQuestion);
                return Ok("Quiz question created successfully.");
            }
        }


        // DELETE: api/QuizQuestions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizQuestion(int id)
        {
            var result = await _quizQuestionsBusiness.DeleteQuizQuestionAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
