using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SlmsAppDataAccess.CourseContent
{
    public class SectionRepository : ISectionRepository
    {
        private readonly SlmsAppContext _context;

        public SectionRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionDto>> GetAllAsync()
        {
            return await _context.Sections
                                 .Where(s => s.IsActive)
                                 .Select(s => new SectionDto
                                 {
                                     SectionId = s.SectionId,
                                     SectionName = s.SectionName,
                                     SectionObjective = s.SectionObjective,
                                     SectionCreatedDate = s.SectionCreatedDate,
                                     SectionUpdatedDate = s.SectionUpdatedDate,
                                     IsActive = s.IsActive,
                                     CreatedByUserId = s.CreatedByUserId,
                                     CreateCourseId = s.CreateCourseId
                                 })
                                 .ToListAsync();
        }

        public async Task<SectionDto> GetByIdAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null) return null;

            return new SectionDto
            {
                SectionId = section.SectionId,
                SectionName = section.SectionName,
                SectionObjective = section.SectionObjective,
                SectionCreatedDate = section.SectionCreatedDate,
                SectionUpdatedDate = section.SectionUpdatedDate,
                IsActive = section.IsActive,
                CreatedByUserId = section.CreatedByUserId,
                CreateCourseId = section.CreateCourseId
            };
        }

        public async Task AddAsync(SectionDto section)
        {
            var newSection = new Section
            {
                SectionName = section.SectionName,
                SectionObjective = section.SectionObjective,
                SectionCreatedDate = section.SectionCreatedDate,
                IsActive = section.IsActive,
                CreatedByUserId = section.CreatedByUserId,
                CreateCourseId = section.CreateCourseId
            };
            _context.Sections.Add(newSection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SectionDto section)
        {
            var existingSection = await _context.Sections.FindAsync(section.SectionId);
            if (existingSection == null) return;

            existingSection.SectionName = section.SectionName;
            existingSection.SectionObjective = section.SectionObjective;
            existingSection.SectionUpdatedDate = section.SectionUpdatedDate;
            existingSection.IsActive = section.IsActive;
            existingSection.CreatedByUserId = section.CreatedByUserId;
            existingSection.CreateCourseId = section.CreateCourseId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null) return;

            section.IsActive = false; // Soft delete
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SectionDto>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Sections
                                 .Where(s => s.CreateCourseId == courseId && s.IsActive)
                                 .Select(s => new SectionDto
                                 {
                                     SectionId = s.SectionId,
                                     SectionName = s.SectionName,
                                     SectionObjective = s.SectionObjective,
                                     SectionCreatedDate = s.SectionCreatedDate,
                                     SectionUpdatedDate = s.SectionUpdatedDate,
                                     IsActive = s.IsActive,
                                     CreatedByUserId = s.CreatedByUserId,
                                     CreateCourseId = s.CreateCourseId
                                 })
                                 .ToListAsync();
        }

    }
}
