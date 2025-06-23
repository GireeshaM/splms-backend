using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Faq
{
    public interface ICourseFaqRepository
    {
        Task<IEnumerable<CourseFaq>> GetAllFaqsAsync();
        Task<IEnumerable<CourseFaq>> GetFaqsByCourseIdAsync(int courseId);
        Task<CourseFaq> GetFaqByIdAsync(int id);
        Task<CourseFaq> AddOrUpdateFaqAsync(CourseFaq faq);
        Task<bool> DeleteFaqAsync(int id);
    }

}
