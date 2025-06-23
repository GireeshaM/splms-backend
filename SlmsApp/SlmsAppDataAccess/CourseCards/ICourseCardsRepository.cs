using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.CourseCards
{
    public interface ICourseCardsRepository
    {
        Task<IEnumerable<CreateCourse>> GetAllCoursesAsync();
        Task<IEnumerable<CreateCourse>> GetCoursesByUserIdAsync(int userId);
        Task<IEnumerable<CreateCourse>> GetEnrolledCoursesByUserIdAsync(int userId);
        Task<IEnumerable<CreateCourse>> GetWishlistedCoursesByUserIdAsync(int userId);
    }
}
