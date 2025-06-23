using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.MyProfiles
{
    public class MyProfileRepository : IMyProfileRepository
    {
        private readonly SlmsAppContext _context;

        public MyProfileRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<Myprofile> GetProfileByUserIdAsync(int userId)
        {
            return await _context.Set<Myprofile>().FindAsync(userId);
        }

        public async Task CreateOrUpdateProfileAsync(Myprofile profile)
        {
            var existing = await _context.Set<Myprofile>().FindAsync(profile.UserId);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(profile);
            }
            else
            {
                await _context.Set<Myprofile>().AddAsync(profile);
            }

            await _context.SaveChangesAsync();
        }
    }
}
