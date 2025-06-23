using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.CourseCards
{
    public class CourseCardsRepository : ICourseCardsRepository
    {
        private readonly SlmsAppContext _context;

        public CourseCardsRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreateCourse>> GetAllCoursesAsync()
        {
            return await _context.CreateCourses.ToListAsync();
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesByUserIdAsync(int userId)
        {
            return await _context.CreateCourses.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<CreateCourse>> GetEnrolledCoursesByUserIdAsync(int userId)
        {
            var courseIds = await _context.CourseEnrollments
                .Where(e => e.UserId == userId)
                .Select(e => e.CreateCourseId)
                .ToListAsync();

            return await _context.CreateCourses.Where(c => courseIds.Contains(c.CreateCourseId)).ToListAsync();
        }

        public async Task<IEnumerable<CreateCourse>> GetWishlistedCoursesByUserIdAsync(int userId)
        {
            var courseIds = await _context.UserWishlistAndVisiteds
                .Where(w => w.UserId == userId && w.CourseWishlist)
                .Select(w => w.CreateCourseId)
                .ToListAsync();

            return await _context.CreateCourses.Where(c => courseIds.Contains(c.CreateCourseId)).ToListAsync();
        }
    }

}