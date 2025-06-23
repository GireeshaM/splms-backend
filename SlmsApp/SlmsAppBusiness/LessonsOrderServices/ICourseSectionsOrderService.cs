using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.LessonsOrderServices
{
    public interface ICourseSectionsOrderService
    {
        Task<IEnumerable<CourseSectionsOrder>> GetSectionOrdersAsync(int userId, int courseId);
        Task CreateOrUpdateSectionOrderAsync(CourseSectionsOrder order);
        Task<bool> SwapSectionOrdersAsync(SwapSectionOrderDto dto);
    }
}
