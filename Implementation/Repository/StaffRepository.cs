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
    public class StaffRepository : IStaffRepository
    {
        private readonly ScanPayContext _context;

        public StaffRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Staff> CreateStaffAsync(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        /*public void DeleteStaff(Staff staff)
        {
            _context.Staffs.Remove(staff);
            _context.SaveChanges();
        }*/

        public async Task<IList<Staff>> GetAllStaffsAsync()
        {
            //var staff = await  _context.Staffs.ToListAsync();
            //return staff;
            var staff = await _context.Staffs.Include(s => s.User).ThenInclude(s => s.UserRoles)

            .ThenInclude(s => s.Role).Where(s=> s.IsDeleted == false).ToListAsync();

            return staff;
        }

        public async Task<IList<Staff>> GetSelectedStaffsAsync(IList<int> ids)
        {
            var staff = await _context.Staffs.Include(s => s.User).ThenInclude(s => s.UserRoles)

            .ThenInclude(s => s.Role).Where(s => ids.Contains(s.Id) && s.IsDeleted == false).ToListAsync();

            return staff;
        }

        public async Task<Staff> GetStaffAsync(int id)
        {
            var staff = await _context.Staffs.Include(s=>s.User).ThenInclude(s=>s.UserRoles)

                .ThenInclude(s=>s.Role).SingleOrDefaultAsync(a => a.Id == id && a.IsDeleted == false);

            return staff;
        }

        public async Task<Staff> GetStaffByStaffcodeAsync(string  staffCode)
        {
            var staff = await _context.Staffs.Include(s => s.User).ThenInclude(s => s.UserRoles)

            .ThenInclude(s => s.Role).SingleOrDefaultAsync(s => s.StaffCode == staffCode && s.IsDeleted == false);

            return staff;
        }

        public async Task<Staff> UpdateStaffAsync(Staff staff)
        {
            _context.Staffs.Update(staff);

           await _context.SaveChangesAsync();

            return staff;

        }
    }
}
