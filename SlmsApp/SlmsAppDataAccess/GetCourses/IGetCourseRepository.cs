using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.GetCourses
{
    public interface IGetCourseRepository
    {
        Task<IEnumerable<CreateCourse>> GetAllCoursesAsync();
        Task<IEnumerable<CreateCourse>> GetCoursesByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CreateCourse>> GetCoursesBySubCategoryIdAsync(int subCategoryId);
        Task<IEnumerable<CreateCourse>> GetCoursesByLevelAsync(string level);
        Task<IEnumerable<CreateCourse>> GetCoursesByDurationAsync(string duration);
        Task<IEnumerable<CreateCourse>> GetCoursesBySkillAsync(string skill);
        Task<IEnumerable<string>> GetAllLevelsAsync();
        Task<IEnumerable<string>> GetAllDurationsAsync();
        Task<IEnumerable<string>> GetAllSkillsAsync();
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();


    }
}
