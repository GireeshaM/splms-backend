using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.CourseEnrollmentRepo
{
    public class CourseEnrollmentRepository : ICourseEnrollmentRepository
    {
        private readonly SlmsAppContext _context;

        public CourseEnrollmentRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseEnrollment>> GetAllAsync() =>
            await _context.Set<CourseEnrollment>().ToListAsync();

        public async Task<CourseEnrollment> GetByIdAsync(int id) =>
            await _context.Set<CourseEnrollment>().FindAsync(id);

        public async Task<IEnumerable<CourseEnrollment>> GetByUserIdAsync(int userId) =>
            await _context.Set<CourseEnrollment>().Where(e => e.UserId == userId).ToListAsync();

        public async Task<IEnumerable<CourseEnrollment>> GetByCourseIdAsync(int courseId) =>
            await _context.Set<CourseEnrollment>().Where(e => e.CreateCourseId == courseId).ToListAsync();

        public async Task<CourseEnrollment> AddOrUpdateAsync(CourseEnrollment enrollment)
        {
            var existing = await _context.Set<CourseEnrollment>()
                .FirstOrDefaultAsync(e => e.UserId == enrollment.UserId && e.CreateCourseId == enrollment.CreateCourseId);

            if (existing != null)
            {
                existing.EnrollmentDate = enrollment.EnrollmentDate;
                existing.IsCompleted = enrollment.IsCompleted;
                _context.Update(existing);
            }
            else
            {
                await _context.AddAsync(enrollment);
            }

            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<CourseEnrollment>().FindAsync(id);
            if (entity == null) return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
