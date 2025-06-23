using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.MyProfiles
{
    public interface IMyProfileRepository
    {
        Task<Myprofile> GetProfileByUserIdAsync(int userId);
        Task CreateOrUpdateProfileAsync(Myprofile profile);
    }
}
