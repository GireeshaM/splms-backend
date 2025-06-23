using Microsoft.Data.SqlClient;
using SlmsAppDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.InstructorCourses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SlmsAppContext _context;

        public CourseRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(CreateCourse course)
        {
            _context.CreateCourses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<int> AddCategoryIfNotExistsAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Category name cannot be null or empty", nameof(name));
            }

            var paramName = new SqlParameter("@Name", name);
            // Log the value for debugging
            Console.WriteLine($"Executing AddCategoryIfNotExists with name: {name}");

            // Execute the stored procedure
            await _context.Database.ExecuteSqlRawAsync("EXEC AddCategoryIfNotExists @Name", paramName);

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
            return category?.CategoriesId ?? throw new Exception("Category not found after insert.");
        }


        public async Task<int> AddSubCategoryIfNotExistsAsync(string name, int categoryId)
        {
            var paramName = new SqlParameter("@Name", name);
            var paramCategoryId = new SqlParameter("@CategoryId", categoryId);

            await _context.Database.ExecuteSqlRawAsync("EXEC AddSubCategoryIfNotExists @Name, @CategoryId", paramName, paramCategoryId);

            var subCategory = await _context.SubCategories
                .FirstOrDefaultAsync(sc => sc.Name == name && sc.CategoryId == categoryId);

            return subCategory?.SubCategoriesId ?? throw new Exception("SubCategory not found after insert.");
        }


        public async Task<CreateCourse> GetByIdAsync(int id)
        {
            return await _context.CreateCourses.FindAsync(id);
        }

        public async Task<int> CreateOrUpdateAsync(CreateCourse course)
        {
            if (course.CreateCourseId > 0)
            {
                // Detach any existing tracked entity with the same key
                var trackedEntity = _context.ChangeTracker.Entries<CreateCourse>()
                    .FirstOrDefault(e => e.Entity.CreateCourseId == course.CreateCourseId);

                if (trackedEntity != null)
                {
                    trackedEntity.State = EntityState.Detached;
                }

                // Optionally: Check if it exists before update (optional but safe)
                var existingEntity = await _context.CreateCourses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CreateCourseId == course.CreateCourseId);

                if (existingEntity == null)
                    throw new Exception("Course not found.");

                _context.CreateCourses.Update(course); // Now safe to update
            }
            else
            {
                await _context.CreateCourses.AddAsync(course);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                // Log the inner exception or write it to the console/log file
                Console.WriteLine($"SaveChanges failed: {inner}");
                throw;
            }
            return course.CreateCourseId;
        }


        public async Task DeleteAsync(int id)
        {
            var course = await _context.CreateCourses.FindAsync(id);
            if (course != null)
            {
                _context.CreateCourses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SubCategory> GetSubCategoryByNameAndCategoryIdAsync(string name, int categoryId)
        {
            return await _context.SubCategories
                .FirstOrDefaultAsync(sc => sc.Name == name && sc.CategoryId == categoryId);
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesByUserIdAsync(int userId)
        {
            return await _context.CreateCourses
                .Where(course => course.UserId == userId)
                .ToListAsync();
        }

        public async Task MarkCourseAsSentToAdminAsync(int courseId)
        {
            var course = await _context.CreateCourses.FindAsync(courseId);
            if (course == null)
                throw new KeyNotFoundException("Course not found.");

            course.AdminReview = true;
            course.CourseUpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task<CreateCourse> GetByTitleAsync(string title)
        {
            return await _context.CreateCourses.FirstOrDefaultAsync(c => c.CourseTitle == title);
        }

        public async Task<CreateCourse> GetUserCourseDetailsAsync(int courseId, int userId)
        {
            var isEnrolled = await _context.CourseEnrollments
                .AnyAsync(e => e.CreateCourseId == courseId && e.UserId == userId);

            if (!isEnrolled)
                return null;

            return await _context.CreateCourses
                .FirstOrDefaultAsync(c => c.CreateCourseId == courseId);
        }
    }

}
