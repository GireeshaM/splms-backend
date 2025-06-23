using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Quiz
{
    public class QuizQuestionsRepository : IQuizQuestionsRepository
    {
        private readonly SlmsAppContext _context;

        public QuizQuestionsRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllAsync()
        {
            return await _context.QuizQuestions.ToListAsync();
        }

        public async Task<QuizQuestion> GetByIdAsync(int id)
        {
            return await _context.QuizQuestions.FindAsync(id);
        }

        public async Task<QuizQuestion> AddAsync(QuizQuestion quizQuestion)
        {
            await _context.QuizQuestions.AddAsync(quizQuestion);
            await _context.SaveChangesAsync();
            return quizQuestion;
        }

        public async Task<bool> UpdateAsync(QuizQuestion quizQuestion)
        {
            _context.QuizQuestions.Update(quizQuestion);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quizQuestion = await _context.QuizQuestions.FindAsync(id);
            if (quizQuestion == null) return false;

            _context.QuizQuestions.Remove(quizQuestion);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
