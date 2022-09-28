using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(Staff staff);

        Task<Staff> UpdateStaffAsync(Staff staff);

        Task<Staff> GetStaffAsync(int id);

        Task<Staff> GetStaffByStaffcodeAsync(string staffCode);

        Task<IList<Staff>> GetAllStaffsAsync();

        Task<IList<Staff>> GetSelectedStaffsAsync(IList<int> ids);

        //void DeleteStaff(Staff staff);
    }
}
  