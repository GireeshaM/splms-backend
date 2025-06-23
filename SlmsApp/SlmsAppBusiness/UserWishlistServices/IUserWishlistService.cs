using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.UserWishlistServices
{
    public interface IUserWishlistService
    {
        Task AddOrUpdateAsync(UserWishlistAndVisitedDto dto);
        Task DeleteWishlistAsync(int userId, int courseId);
        Task<IEnumerable<UserWishlistAndVisitedDto>> GetWishlistByUserAsync(int userId);
        Task<IEnumerable<UserWishlistAndVisitedDto>> GetWishlistByCourseAsync(int courseId);
        Task<IEnumerable<UserWishlistAndVisitedDto>> GetVisitedByUserAsync(int userId);
        Task<IEnumerable<UserWishlistAndVisitedDto>> GetVisitedByCourseAsync(int courseId);
    }
}
