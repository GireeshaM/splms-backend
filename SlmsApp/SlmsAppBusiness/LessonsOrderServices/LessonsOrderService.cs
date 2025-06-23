using SlmsAppDataAccess.LessonsOrderRepo;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.LessonsOrderServices
{
    public class LessonsOrderService : ILessonsOrderService
    {
        private readonly ILessonsOrderRepository _repo;
        public LessonsOrderService(ILessonsOrderRepository repo)
        {
            _repo = repo;
        }

        public Task SaveOrUpdateOrdersAsync(List<LessonsOrderDto> orders)
        {
            return _repo.SaveOrUpdateOrdersAsync(orders);
        }

        public Task<int?> GetOrderIdByVideoIdAsync(int videoId)
        {
            return _repo.GetOrderIdByVideoIdAsync(videoId);
        }

        public Task<int?> GetOrderIdByQuizIdAsync(int quizId)
        {
            return _repo.GetOrderIdByQuizIdAsync(quizId);
        }
    }
}
