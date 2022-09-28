using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddCustomerAsync(CreateCustomerRequestModel model);

        Task<bool> UpdateCustomerAsync(int id, UpdateCustomerRequestModel model);

        Task<CustomerDto> GetCustomerAsync(int id);

        Task<CustomerDto> GetCustomerByEmailAsync(string email);

        Task<IList<CustomerDto>> GetAllCustomersAsync();

        Task<bool> DeleteCustomerAsync(int id);

        
    }
}
