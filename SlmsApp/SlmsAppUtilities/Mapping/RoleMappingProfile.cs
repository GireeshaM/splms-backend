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
    public class RoleMappingProfile :Profile
    {
        public RoleMappingProfile() 
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
