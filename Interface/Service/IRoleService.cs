using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IRoleService
    {
        Task<RoleDto> AddRoleAsync(CreateRoleRequestModel model);

        Task<bool> UpdateRoleAsync(int id, UpdateRoleRequestModel model);

        Task<RoleDto> GetRoleAsync(int id);

        Task<IList<RoleDto>> GetAllRolesAsync();

        Task<IList<RoleDto>> GetAllStaffRolesAsync();

        Task<RoleDto> GetRoleByNameAsync(string name);

        Task<bool> DeleteRoleAsync(int id);


    }
}
