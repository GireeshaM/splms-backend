using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.LessonsOrderServices
{
    public interface ILessonsOrderService
    {
        Task SaveOrUpdateOrdersAsync(List<LessonsOrderDto> orders);
        Task<int?> GetOrderIdByVideoIdAsync(int videoId);
        Task<int?> GetOrderIdByQuizIdAsync(int quizId);
    }
}
