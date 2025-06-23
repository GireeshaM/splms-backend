using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CourseCardsServices
{
    public interface ICourseCardsService
    {
        Task<IEnumerable<CourseCardDto>> GetAllCourseCardsAsync();
        Task<IEnumerable<CourseCardDto>> GetCourseCardsByUserIdAsync(int userId);
        Task<IEnumerable<CourseCardDto>> GetEnrolledCoursesAsync(int userId);
        Task<IEnumerable<CourseCardDto>> GetWishlistedCoursesAsync(int userId);
    }
}
