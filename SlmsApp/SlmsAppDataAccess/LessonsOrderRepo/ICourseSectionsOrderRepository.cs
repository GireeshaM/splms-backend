using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.LessonsOrderRepo
{
    public interface ICourseSectionsOrderRepository
    {
        Task<IEnumerable<CourseSectionsOrder>> GetByUserAndCourseAsync(int userId, int courseId);
        Task<CourseSectionsOrder?> GetByUserCourseSectionAsync(int userId, int courseId, int sectionId);
        Task AddAsync(CourseSectionsOrder entity);
        void Update(CourseSectionsOrder entity);
        Task SaveChangesAsync();
    }

}
