using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.QuizService
{
    public class QuizQuestionsBusiness : IQuizQuestionsBusiness
    {
        private readonly IQuizQuestionsRepository _quizQuestionsRepository;

        public QuizQuestionsBusiness(IQuizQuestionsRepository quizQuestionsRepository)
        {
            _quizQuestionsRepository = quizQuestionsRepository;
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllQuizQuestionsAsync()
        {
            return await _quizQuestionsRepository.GetAllAsync();
        }

        public async Task<QuizQuestion> GetQuizQuestionByIdAsync(int id)
        {
            return await _quizQuestionsRepository.GetByIdAsync(id);
        }

        public async Task<QuizQuestion> CreateQuizQuestionAsync(QuizQuestion quizQuestion)
        {
            return await _quizQuestionsRepository.AddAsync(quizQuestion);
        }

        public async Task<bool> UpdateQuizQuestionAsync(QuizQuestion quizQuestion)
        {
            return await _quizQuestionsRepository.UpdateAsync(quizQuestion);
        }

        public async Task<bool> DeleteQuizQuestionAsync(int id)
        {
            return await _quizQuestionsRepository.DeleteAsync(id);
        }
    }
}
