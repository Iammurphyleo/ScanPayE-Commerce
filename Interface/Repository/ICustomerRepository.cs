using Scanpay.Dtos;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);

        Task<Customer> UpdateCustomerAsync(Customer customer);

        Task<Customer> GetCustomerAsync(int id);

        Task<Customer> GetCustomerByEmailAsync(string email);

        Task<IList<Customer>> GetAllCustomersAsync();

        //void DeleteCustomer(Customer customer);

        Task<IList<Customer>> GetSelectedCustomersAsync(IList<int> ids);


    }
}
