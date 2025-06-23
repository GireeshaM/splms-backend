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
    public class MyProfileMappingProfile :Profile
    {
        public MyProfileMappingProfile() 
        { 
            CreateMap<Myprofile,MyProfileDto>().ReverseMap();
        }
    }
}
