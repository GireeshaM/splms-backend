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
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile() 
        {
            CreateMap<Video, AddVideotoVideo>().ReverseMap();
            CreateMap<Video, VideoSummeryDto>().ReverseMap();
            CreateMap<LessonsOrder, LessonsOrderDto>().ReverseMap();
            CreateMap<CourseSectionsOrder, CourseSectionsOrderDto>().ReverseMap();
            CreateMap<CourseSectionsOrder, SwapSectionOrderDto>().ReverseMap();
        }
    }
}
