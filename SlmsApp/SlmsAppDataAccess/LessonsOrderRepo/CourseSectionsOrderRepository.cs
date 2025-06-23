using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.LessonsOrderRepo
{
    public class CourseSectionsOrderRepository : ICourseSectionsOrderRepository
    {
        private readonly SlmsAppContext _context;

        public CourseSectionsOrderRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseSectionsOrder>> GetByUserAndCourseAsync(int userId, int courseId)
        {
            return await _context.CourseSectionsOrders
                .Where(c => c.UserId == userId && c.CreateCourseId == courseId)
                .OrderBy(c => c.SectionOrder)
                .ToListAsync();
        }

        public async Task<CourseSectionsOrder?> GetByUserCourseSectionAsync(int userId, int courseId, int sectionId)
        {
            return await _context.CourseSectionsOrders
                .FirstOrDefaultAsync(c => c.UserId == userId && c.CreateCourseId == courseId && c.SectionId == sectionId);
        }

        public async Task AddAsync(CourseSectionsOrder entity)
        {
            await _context.CourseSectionsOrders.AddAsync(entity);
        }

        public void Update(CourseSectionsOrder entity)
        {
            _context.CourseSectionsOrders.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
