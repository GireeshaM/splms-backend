using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.QuizService
{
    public interface IQuizAnswerService
    {
        Task<List<QuizAnswerDto>> GetAllQuizAnswersAsync();
        Task<QuizAnswerDto> GetQuizAnswerByIdAsync(int id);
        Task<QuizAnswerDto> AddQuizAnswerAsync(QuizAnswerDto quizAnswerDto);
        Task<QuizAnswerDto> UpdateQuizAnswerAsync(QuizAnswerDto quizAnswerDto);
        Task DeleteQuizAnswerAsync(int id);
        Task<List<QuizAnswerDto>> GetAnswersByQuestionIdAsync(int questionId);

    }
}
