using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.FaqSevicees
{

    public interface ICourseFaqService
    {
        Task<IEnumerable<CourseFaqDto>> GetAllFaqsAsync();
        Task<IEnumerable<CourseFaqDto>> GetFaqsByCourseIdAsync(int courseId);
        Task<CourseFaqDto> AddOrUpdateFaqAsync(CourseFaqDto faqDto);
        Task<bool> DeleteFaqAsync(int id);
    }

}
