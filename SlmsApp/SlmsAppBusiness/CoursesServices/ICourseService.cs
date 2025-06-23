using SlmsAppModels;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CoursesServices
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CreateCourseDto courseDto); // Create a new course (after handling categories and subcategories)
        Task<CreateCourseDto> GetByIdAsync(int id); // Get a course DTO by its ID
        Task<int> CreateOrUpdateAsync(CreateCourseDto dto); // Create or update a course based on the DTO
        Task DeleteAsync(int id); // Delete a course by its ID
        Task<int> AddCategoryIfNotExistsAsync(string name);
        Task<int> AddSubCategoryIfNotExistsAsync(string name, int categoryId);
        Task<IEnumerable<CreateCourseDto>> GetCoursesByUserIdAsync(int userId); // Get all courses for a specific user
        Task MarkCourseAsSentToAdminAsync(int courseId);
        Task<UserCourseDetailsDto> FetchUserCourseDetailsAsync(int courseId, int userId);

    }

}