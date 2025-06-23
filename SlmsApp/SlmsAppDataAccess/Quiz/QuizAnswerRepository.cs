using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Quiz
{
    public class QuizAnswerRepository : IQuizAnswerRepository
    {
        private readonly SlmsAppContext _context;

        public QuizAnswerRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<List<QuizAnswer>> GetAllQuizAnswersAsync()
        {
            return await _context.QuizAnswers.ToListAsync();
        }

        public async Task<QuizAnswer> GetQuizAnswerByIdAsync(int id)
        {
            return await _context.QuizAnswers.FindAsync(id);
        }

        public async Task<QuizAnswer> AddQuizAnswerAsync(QuizAnswer quizAnswer)
        {
            _context.QuizAnswers.Add(quizAnswer);
            await _context.SaveChangesAsync();
            return quizAnswer;
        }

        public async Task<QuizAnswer> UpdateQuizAnswerAsync(QuizAnswer quizAnswer)
        {
            _context.QuizAnswers.Update(quizAnswer);
            await _context.SaveChangesAsync();
            return quizAnswer;
        }

        public async Task DeleteQuizAnswerAsync(int id)
        {
            var quizAnswer = await _context.QuizAnswers.FindAsync(id);
            if (quizAnswer != null)
            {
                _context.QuizAnswers.Remove(quizAnswer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<QuizAnswer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.QuizAnswers
                                 .Where(a => a.QuizQuestionId == questionId)
                                 .ToListAsync();
        }

    }
}
