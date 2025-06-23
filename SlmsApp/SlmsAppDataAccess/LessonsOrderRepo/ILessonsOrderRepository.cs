using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.LessonsOrderRepo
{
    public interface ILessonsOrderRepository
    {
        Task SaveOrUpdateOrdersAsync(List<LessonsOrderDto> orders);
        Task<int?> GetOrderIdByVideoIdAsync(int videoId);
        Task<int?> GetOrderIdByQuizIdAsync(int quizId);
        Task DeleteByVideoIdAsync(int videoId);
        Task DeleteByQuizIdAsync(int quizId);
    }

}
