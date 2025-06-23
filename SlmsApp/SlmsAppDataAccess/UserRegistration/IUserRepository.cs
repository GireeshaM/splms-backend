using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.UserRegistration
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<bool> SaveChangesAsync();
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(int id);
        Task DeleteUserAsync(User user);
        Task AddUserInterestsAsync(List<UserInterest> interests);
        User GetByEmail(string email);
        void Update(User user);
        void Save();

    }

}
