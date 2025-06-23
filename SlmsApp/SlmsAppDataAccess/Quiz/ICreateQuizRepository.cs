using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Quiz
{
    public interface ICreateQuizRepository
    {
        Task<IEnumerable<CreateQuiz>> GetAllAsync();
        Task<CreateQuiz> GetByIdAsync(int id);
        Task AddAsync(CreateQuiz quiz);
        Task UpdateAsync(CreateQuiz quiz);
        Task DeleteAsync(int id);
    }
}
