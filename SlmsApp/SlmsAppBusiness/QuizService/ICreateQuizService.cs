using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.QuizService
{
    public interface ICreateQuizService
    {
        Task<IEnumerable<CreateQuizDto>> GetAllAsync();
        Task<CreateQuizDto> GetByIdAsync(int id);
        Task<CreateQuiz> AddAsync(CreateQuizDto quizDto);
        Task UpdateAsync(int id, CreateQuizDto quizDto);
        Task DeleteAsync(int id);
    }
}
