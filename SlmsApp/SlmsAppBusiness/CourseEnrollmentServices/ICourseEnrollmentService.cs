using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CourseEnrollmentServices
{
    public interface ICourseEnrollmentService
    {
        Task<IEnumerable<CourseEnrollmentDto>> GetAllAsync();
        Task<CourseEnrollmentDto> GetByIdAsync(int id);
        Task<IEnumerable<CourseEnrollmentDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<CourseEnrollmentDto>> GetByCourseIdAsync(int courseId);
        Task<CourseEnrollmentDto> AddOrUpdateAsync(CourseEnrollmentDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
