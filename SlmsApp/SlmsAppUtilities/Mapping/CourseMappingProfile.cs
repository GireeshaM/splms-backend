using AutoMapper;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppUtilities.Mapping
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            // DTO → Entity


            CreateMap<CreateCourseDto, CreateCourse>()
                .ForMember(dest => dest.PreRequirements, opt => opt.MapFrom(src => src.PreRequirements != null ? string.Join(",", src.PreRequirements) : null))
                .ForMember(dest => dest.SkillsYouGain, opt => opt.MapFrom(src => src.SkillsYouGain != null ? string.Join(",", src.SkillsYouGain) : null))
                .ForMember(dest => dest.WhatYouWillLearn, opt => opt.MapFrom(src => src.WhatYouWillLearn != null ? string.Join(",", src.WhatYouWillLearn) : null));

            // Entity → DTO
            CreateMap<CreateCourse, CreateCourseDto>()
                .ForMember(dest => dest.PreRequirements, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.PreRequirements) ? Array.Empty<string>() : src.PreRequirements.Split(",", StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.SkillsYouGain, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.SkillsYouGain) ? Array.Empty<string>() : src.SkillsYouGain.Split(",", StringSplitOptions.RemoveEmptyEntries)))
                .ForMember(dest => dest.WhatYouWillLearn, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.WhatYouWillLearn) ? Array.Empty<string>() : src.WhatYouWillLearn.Split(",", StringSplitOptions.RemoveEmptyEntries)));

            CreateMap<CreateCourse, UserCourseDetailsDto>().ForMember(dest => dest.PreRequirements, opt => opt.MapFrom(src =>
                string.IsNullOrEmpty(src.PreRequirements) ? Array.Empty<string>() : src.PreRequirements.Split(",", StringSplitOptions.RemoveEmptyEntries)))
            .ForMember(dest => dest.SkillsYouGain, opt => opt.MapFrom(src =>
                string.IsNullOrEmpty(src.SkillsYouGain) ? Array.Empty<string>() : src.SkillsYouGain.Split(",", StringSplitOptions.RemoveEmptyEntries)))
            .ForMember(dest => dest.WhatYouWillLearn, opt => opt.MapFrom(src =>
                string.IsNullOrEmpty(src.WhatYouWillLearn) ? Array.Empty<string>() : src.WhatYouWillLearn.Split(",", StringSplitOptions.RemoveEmptyEntries)));


        }
    
    }
}
