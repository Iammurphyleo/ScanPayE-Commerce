using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ScanPayContext _context;

        public RoleRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        /*public void DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }*/

        public async Task<Role> GetRoleAsync(int id)
        {
            var role = await _context.Roles.Include(r => r.UserRoles).ThenInclude(r => r.User)

                .Where(r => r.Id == id && r.IsDeleted == false).SingleOrDefaultAsync();

            return role;
        }

        public async Task<IList<Role>> GetAllRolesAsync()
        {
            var role = await _context.Roles.Where(r => r.IsDeleted == false).ToListAsync();
            return role;
        }

        public async Task<IList<Role>> GetSelectedRolesAsync(IList<int> ids)
        {
            var role = await _context.Roles.Include(r => r.UserRoles).ThenInclude(r => r.User)

            .Where(r => ids.Contains(r.Id) && r.IsDeleted == false).ToListAsync();

            return role;
        }


        public async Task<Role> UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            var role = await _context.Roles.Include(r => r.UserRoles).ThenInclude(r => r.User)

            .Where(r => r.Name == name && r.IsDeleted == false).SingleOrDefaultAsync();

            return role;
        }

        public async Task<IList<Role>> GetAllStaffRolesAsync()
        {
            var role = await _context.Roles.Where(r => r.Name != "Customer" && r.IsDeleted == false).ToListAsync();

            return role;
        }



    }
}