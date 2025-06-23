using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppUtilities.Mapping
{
    public class CourseEnrollmentMappingProfile : Profile
    {
        public CourseEnrollmentMappingProfile()
        {
            CreateMap<CourseEnrollment, CourseEnrollmentDto>().ReverseMap();
        }
    }
   
}
