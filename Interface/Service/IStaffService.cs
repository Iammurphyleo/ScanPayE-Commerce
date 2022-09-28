using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IStaffService
    {
        Task<StaffDto> AddStaffAsync(CreateStaffRequestModel model);

        Task<bool> UpdateStaffAsync(int id, UpdateStaffRequestModel model);

        Task<StaffDto> GetStaffAsync(int id);

        Task<StaffDto> GetStaffByStaffcodeAsync(string staffCode);

        Task<IList<StaffDto>> GetAllStaffsAsync();

        Task<bool> DeleteStaffAsync(int id);

           
    }
}
