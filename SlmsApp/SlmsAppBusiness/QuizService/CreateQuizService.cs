using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.QuizService
{
    public class CreateQuizService : ICreateQuizService
    {
        private readonly SlmsAppContext _context;

        public CreateQuizService(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreateQuizDto>> GetAllAsync()
        {
            return await _context.CreateQuizzes
                .Select(q => new CreateQuizDto
                {
                    CreateQuizId = q.CreateQuizId,
                    QuizTitle = q.QuizTitle,
                    QuizDescription = q.QuizDescription,
                    QuizCreationTime = q.QuizCreationTime,
                    QuizUpdateTime = q.QuizUpdateTime,
                    SectionId = q.SectionId,
                    CreatedByUserId = q.CreatedByUserId
                })
                .ToListAsync();
        }

        public async Task<CreateQuizDto> GetByIdAsync(int id)
        {
            var quiz = await _context.CreateQuizzes.FindAsync(id);
            if (quiz == null)
                return null;

            return new CreateQuizDto
            {
                CreateQuizId = quiz.CreateQuizId,
                QuizTitle = quiz.QuizTitle,
                QuizDescription = quiz.QuizDescription,
                QuizCreationTime = quiz.QuizCreationTime,
                QuizUpdateTime = quiz.QuizUpdateTime,
                SectionId = quiz.SectionId,
                CreatedByUserId = quiz.CreatedByUserId
            };
        }

        public async Task<CreateQuiz> AddAsync(CreateQuizDto quizDto)
        {
            if (quizDto.SectionId <= 0)
                throw new ArgumentException("Section ID must be greater than zero.");

            var quiz = new CreateQuiz
            {
                QuizTitle = quizDto.QuizTitle,
                QuizDescription = quizDto.QuizDescription,
                QuizCreationTime = DateTime.UtcNow,
                SectionId = quizDto.SectionId,
                CreatedByUserId = quizDto.CreatedByUserId
            };

            _context.CreateQuizzes.Add(quiz);
            await _context.SaveChangesAsync();

            return quiz; // you can also map this back to a DTO if needed
        }


        public async Task UpdateAsync(int id, CreateQuizDto quizDto)
        {
            var quiz = await _context.CreateQuizzes.FindAsync(id);
            if (quiz == null) return;

            quiz.QuizTitle = quizDto.QuizTitle;
            quiz.QuizDescription = quizDto.QuizDescription;
            quiz.QuizUpdateTime = DateTime.UtcNow;
            quiz.SectionId = quizDto.SectionId;
            quiz.CreatedByUserId = quizDto.CreatedByUserId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _context.CreateQuizzes.FindAsync(id);
            if (quiz == null) return;

            _context.CreateQuizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }
    }
}
