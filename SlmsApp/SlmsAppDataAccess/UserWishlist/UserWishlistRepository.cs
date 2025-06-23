using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.UserWishlist
{
    public class UserWishlistRepository : IUserWishlistRepository
    {
        private readonly SlmsAppContext _context;

        public UserWishlistRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<UserWishlistAndVisited> GetAsync(int userId, int courseId) =>
            await _context.UserWishlistAndVisiteds
                .FirstOrDefaultAsync(x => x.UserId == userId && x.CreateCourseId == courseId);

        public async Task<IEnumerable<UserWishlistAndVisited>> GetWishlistByUserAsync(int userId) =>
            await _context.UserWishlistAndVisiteds
                .Where(x => x.UserId == userId && x.CourseWishlist)
                .ToListAsync();

        public async Task<IEnumerable<UserWishlistAndVisited>> GetWishlistByCourseAsync(int courseId) =>
            await _context.UserWishlistAndVisiteds
                .Where(x => x.CreateCourseId == courseId && x.CourseWishlist)
                .ToListAsync();

        public async Task<IEnumerable<UserWishlistAndVisited>> GetVisitedByUserAsync(int userId) =>
            await _context.UserWishlistAndVisiteds
                .Where(x => x.UserId == userId && x.CourseVisited)
                .ToListAsync();

        public async Task<IEnumerable<UserWishlistAndVisited>> GetVisitedByCourseAsync(int courseId) =>
            await _context.UserWishlistAndVisiteds
                .Where(x => x.CreateCourseId == courseId && x.CourseVisited)
                .ToListAsync();

        public async Task AddAsync(UserWishlistAndVisited entity)
        {
            _context.UserWishlistAndVisiteds.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserWishlistAndVisited entity)
        {
            _context.UserWishlistAndVisiteds.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int courseId)
        {
            var entity = await GetAsync(userId, courseId);
            if (entity != null)
            {
                _context.UserWishlistAndVisiteds.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}