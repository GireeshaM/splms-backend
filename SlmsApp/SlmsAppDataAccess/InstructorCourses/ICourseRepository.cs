using SlmsAppDataAccess.Models;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.InstructorCourses
{
    public interface ICourseRepository
    {
        Task<CreateCourse> GetByTitleAsync(string title);
        Task AddCourseAsync(CreateCourse course);
        Task<int> AddCategoryIfNotExistsAsync(string name);
        Task<int> AddSubCategoryIfNotExistsAsync(string name, int categoryId);
        Task<CreateCourse> GetByIdAsync(int id);
        Task<int> CreateOrUpdateAsync(CreateCourse course);
        Task DeleteAsync(int id);
        Task<SubCategory> GetSubCategoryByNameAndCategoryIdAsync(string name, int categoryId);
        Task<IEnumerable<CreateCourse>> GetCoursesByUserIdAsync(int userId); // New method to fetch courses by user ID
        Task MarkCourseAsSentToAdminAsync(int courseId);
        Task<CreateCourse> GetUserCourseDetailsAsync(int courseId, int userId);

    }


}