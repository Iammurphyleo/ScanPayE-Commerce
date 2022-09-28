using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IRoleRepository
    {
        Task<Role> CreateRoleAsync(Role role);

        Task<Role> UpdateRoleAsync(Role role);

        Task<Role> GetRoleAsync(int id);

        Task<Role> GetRoleByNameAsync(string name);

        Task<IList<Role>> GetAllRolesAsync();

        Task<IList<Role>> GetAllStaffRolesAsync();

        //void DeleteRole(Role role);

        Task<IList<Role>> GetSelectedRolesAsync(IList<int> ids);
    }
}
