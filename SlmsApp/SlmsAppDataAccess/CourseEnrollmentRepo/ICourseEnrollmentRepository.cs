using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.CourseEnrollmentRepo
{
    public interface ICourseEnrollmentRepository
    {
        Task<IEnumerable<CourseEnrollment>> GetAllAsync();
        Task<CourseEnrollment> GetByIdAsync(int id);
        Task<IEnumerable<CourseEnrollment>> GetByUserIdAsync(int userId);
        Task<IEnumerable<CourseEnrollment>> GetByCourseIdAsync(int courseId);
        Task<CourseEnrollment> AddOrUpdateAsync(CourseEnrollment enrollment);
        Task<bool> DeleteAsync(int id);
    }

}
