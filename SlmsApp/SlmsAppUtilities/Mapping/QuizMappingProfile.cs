using AutoMapper;
using SlmsAppModels;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppUtilities.Mapping
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile() 
        {
            CreateMap<CreateQuiz, CreateQuizDto>().ReverseMap();
            CreateMap<QuizQuestion, QuizQuestionDTO>().ReverseMap();
            CreateMap<QuizAnswer, QuizAnswerDto>().ReverseMap();

        }
    }
}
