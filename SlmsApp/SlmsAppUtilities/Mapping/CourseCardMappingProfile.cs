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
    public class CourseCardMappingProfile :Profile
    {
       public CourseCardMappingProfile()
        {
            CreateMap<CreateCourse, CourseCardDto>()
            .ForMember(dest => dest.FullName, opt => opt.Ignore())
            .ForMember(dest => dest.PhotoPath, opt => opt.Ignore())
            .ForMember(dest => dest.VideoDuration, opt => opt.Ignore())
            .ForMember(dest => dest.EnrollmentId, opt => opt.Ignore())
            .ForMember(dest => dest.UserInteractionId, opt => opt.Ignore())
            .ForMember(dest => dest.IsEnrolled, opt => opt.Ignore())
            .ForMember(dest => dest.IsWishlisted, opt => opt.Ignore());
        }
    }
}
