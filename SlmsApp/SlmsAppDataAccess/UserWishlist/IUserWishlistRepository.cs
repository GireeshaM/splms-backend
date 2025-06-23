using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.UserWishlist
{
    public interface IUserWishlistRepository
    {
        Task<UserWishlistAndVisited> GetAsync(int userId, int courseId);
        Task<IEnumerable<UserWishlistAndVisited>> GetWishlistByUserAsync(int userId);
        Task<IEnumerable<UserWishlistAndVisited>> GetWishlistByCourseAsync(int courseId);
        Task<IEnumerable<UserWishlistAndVisited>> GetVisitedByUserAsync(int userId);
        Task<IEnumerable<UserWishlistAndVisited>> GetVisitedByCourseAsync(int courseId);
        Task AddAsync(UserWishlistAndVisited entity);
        Task UpdateAsync(UserWishlistAndVisited entity);
        Task DeleteAsync(int userId, int courseId);
    }
}
