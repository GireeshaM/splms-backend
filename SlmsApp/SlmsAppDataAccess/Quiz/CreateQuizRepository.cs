using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Quiz
{
    public class CreateQuizRepository : ICreateQuizRepository
    {
        private readonly SlmsAppContext _context;

        public CreateQuizRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreateQuiz>> GetAllAsync()
        {
            return await _context.CreateQuizzes
                .Include(q => q.Section)
                .Include(q => q.CreatedByUser)
                .ToListAsync();
        }

        public async Task<CreateQuiz> GetByIdAsync(int id)
        {
            return await _context.CreateQuizzes
                .Include(q => q.Section)
                .Include(q => q.CreatedByUser)
                .FirstOrDefaultAsync(q => q.CreateQuizId == id);
        }

        public async Task AddAsync(CreateQuiz quiz)
        {
            _context.CreateQuizzes.Add(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CreateQuiz quiz)
        {
            _context.Entry(quiz).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _context.CreateQuizzes.FindAsync(id);
            if (quiz != null)
            {
                _context.CreateQuizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }
    }
}
