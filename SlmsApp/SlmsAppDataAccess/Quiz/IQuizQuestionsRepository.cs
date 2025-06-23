using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Quiz
{
    public interface IQuizQuestionsRepository
    {
        Task<IEnumerable<QuizQuestion>> GetAllAsync();
        Task<QuizQuestion> GetByIdAsync(int id);
        Task<QuizQuestion> AddAsync(QuizQuestion quizQuestion);
        Task<bool> UpdateAsync(QuizQuestion quizQuestion);
        Task<bool> DeleteAsync(int id);
    }
}
