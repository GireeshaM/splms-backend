using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.ProfileService
{
    public interface IMyProfileService
    {
        Task<MyProfileDto> GetProfileByUserIdAsync(int userId);
        Task CreateOrUpdateProfileAsync(MyProfileDto profileDto);
    }
}
