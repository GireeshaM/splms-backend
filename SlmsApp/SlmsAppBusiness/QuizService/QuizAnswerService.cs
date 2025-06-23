using AutoMapper;
using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.Quiz;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.QuizService
{
    public class QuizAnswerService : IQuizAnswerService
    {
        private readonly IQuizAnswerRepository _repository;
        private readonly IMapper _mapper;

        public QuizAnswerService(IQuizAnswerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<QuizAnswerDto>> GetAllQuizAnswersAsync()
        {
            var quizAnswers = await _repository.GetAllQuizAnswersAsync();
            return _mapper.Map<List<QuizAnswerDto>>(quizAnswers);
        }

        public async Task<QuizAnswerDto> GetQuizAnswerByIdAsync(int id)
        {
            var quizAnswer = await _repository.GetQuizAnswerByIdAsync(id);
            return _mapper.Map<QuizAnswerDto>(quizAnswer);
        }

        public async Task<QuizAnswerDto> AddQuizAnswerAsync(QuizAnswerDto quizAnswerDto)
        {
            var quizAnswer = _mapper.Map<QuizAnswer>(quizAnswerDto);
            var addedQuizAnswer = await _repository.AddQuizAnswerAsync(quizAnswer);
            return _mapper.Map<QuizAnswerDto>(addedQuizAnswer);
        }

        public async Task<QuizAnswerDto> UpdateQuizAnswerAsync(QuizAnswerDto quizAnswerDto)
        {
            var quizAnswer = _mapper.Map<QuizAnswer>(quizAnswerDto);
            var updatedQuizAnswer = await _repository.UpdateQuizAnswerAsync(quizAnswer);
            return _mapper.Map<QuizAnswerDto>(updatedQuizAnswer);
        }

        public async Task DeleteQuizAnswerAsync(int id)
        {
            await _repository.DeleteQuizAnswerAsync(id);
        }

        public async Task<List<QuizAnswerDto>> GetAnswersByQuestionIdAsync(int questionId)
        {
            var answers = await _repository.GetAnswersByQuestionIdAsync(questionId);
            return _mapper.Map<List<QuizAnswerDto>>(answers);
        }

    }
}
