using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.Roels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync() =>
            await _roleRepository.GetAllAsync();

        public async Task<Role> GetRoleByIdAsync(int id) =>
            await _roleRepository.GetByIdAsync(id);

        public async Task CreateRoleAsync(Role role) =>
            await _roleRepository.AddAsync(role);

        public async Task UpdateRoleAsync(Role role) =>
            await _roleRepository.UpdateAsync(role);

        public async Task DeleteRoleAsync(int id) =>
            await _roleRepository.DeleteAsync(id);
    }

}
