using AutoMapper;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SlmsAppUtilities.Mapping
{
    public class SectionMappingProfile :Profile
    {
        public SectionMappingProfile()
        {
            CreateMap<Section, SectionDto>().ReverseMap();

        }
    }
}
