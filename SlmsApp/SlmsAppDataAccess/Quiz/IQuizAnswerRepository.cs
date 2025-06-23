using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Quiz
{
    public interface IQuizAnswerRepository
    {
        Task<List<QuizAnswer>> GetAllQuizAnswersAsync();
        Task<QuizAnswer> GetQuizAnswerByIdAsync(int id);
        Task<QuizAnswer> AddQuizAnswerAsync(QuizAnswer quizAnswer);
        Task<QuizAnswer> UpdateQuizAnswerAsync(QuizAnswer quizAnswer);
        Task DeleteQuizAnswerAsync(int id);
        Task<List<QuizAnswer>> GetAnswersByQuestionIdAsync(int questionId);

    }
}
