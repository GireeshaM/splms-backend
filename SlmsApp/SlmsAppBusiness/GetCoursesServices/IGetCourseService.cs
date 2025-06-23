using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.GetCoursesServices
{
    public interface IGetCourseService
    {
        Task<IEnumerable<CreateCourseDto>> GetAllCoursesAsync();
        Task<IEnumerable<CreateCourseDto>> GetCoursesByCategoryAsync(int categoryId);
        Task<IEnumerable<CreateCourseDto>> GetCoursesBySubCategoryAsync(int subCategoryId);
        Task<IEnumerable<CreateCourseDto>> GetCoursesByLevelAsync(string level);
        Task<IEnumerable<CreateCourseDto>> GetCoursesByDurationAsync(string duration);
        Task<IEnumerable<CreateCourseDto>> GetCoursesBySkillAsync(string skill);
        Task<IEnumerable<string>> GetAllLevelsAsync();
        Task<IEnumerable<string>> GetAllDurationsAsync();
        Task<IEnumerable<string>> GetAllSkillsAsync();
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync();
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();


    }
}
