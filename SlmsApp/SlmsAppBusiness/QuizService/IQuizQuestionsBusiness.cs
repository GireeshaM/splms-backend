using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.QuizService
{
    public interface IQuizQuestionsBusiness
    {
        Task<IEnumerable<QuizQuestion>> GetAllQuizQuestionsAsync();
        Task<QuizQuestion> GetQuizQuestionByIdAsync(int id);
        Task<QuizQuestion> CreateQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<bool> UpdateQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<bool> DeleteQuizQuestionAsync(int id);
    }
}
