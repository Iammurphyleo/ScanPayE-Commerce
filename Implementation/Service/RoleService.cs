using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> AddRoleAsync(CreateRoleRequestModel model)
        {
            var role = new Role
            {
                Name = model.Name,

                Description = model.Description,
                
            };
            var roleinfo = await _roleRepository.CreateRoleAsync(role);
            return new RoleDto 
            { 
                Name = roleinfo.Name,

                Description = roleinfo.Description,

                Id = roleinfo.Id
                
            };

        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role =await  _roleRepository.GetRoleAsync(id);

            role.IsDeleted = true;

            await _roleRepository.UpdateRoleAsync(role);

           // _roleRepository.DeleteRole(role);

            return true;

        }

        public async Task<IList<RoleDto>> GetAllRolesAsync()
        {
            var role = await _roleRepository.GetAllRolesAsync();

            var roles = role.ToList().Select(r => new RoleDto
            {
                Id = r.Id,
                Description = r.Description,
                Name = r.Name,
                
            }).ToList();
            return roles;

        }

        public async Task<IList<RoleDto>> GetAllStaffRolesAsync()
        {
            var role = await _roleRepository.GetAllStaffRolesAsync();

            var roles = role.Where(r=>r.Name != "Customer").ToList().Select(r => new RoleDto
            {
                Id = r.Id,
                Description = r.Description,
                Name = r.Name,

            }).ToList();
            return roles;
        }

        public async Task<RoleDto> GetRoleAsync(int id)
        {
            var role = await _roleRepository.GetRoleAsync(id);
            return new RoleDto
            {
                Id = role.Id,
                Description = role.Description,
                Name = role.Name
            };
        }

        public async Task<RoleDto> GetRoleByNameAsync(string name)
        {
            var role = await _roleRepository.GetRoleByNameAsync(name);
            return new RoleDto
            {
                Id = role.Id,
                Description = role.Description,
                Name = role.Name
            };

        }

        public async Task<bool> UpdateRoleAsync(int id, UpdateRoleRequestModel model)
        {
            var role = await _roleRepository.GetRoleAsync(id);

            role.Name = model.Name;
            role.Description = model.Description;

            await _roleRepository.UpdateRoleAsync(role);
            return true;
            

        }
    }
}
