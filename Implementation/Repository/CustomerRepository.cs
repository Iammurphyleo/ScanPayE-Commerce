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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ScanPayContext _context;

        public CustomerRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
           await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

       /* public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }*/

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            var customer = await _context.Customers.Where(c => c.IsDeleted == false).ToListAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.Include(c => c.Orders)

            .ThenInclude(c => c.Payment).Include(c => c.Carts).ThenInclude(c=>c.CartItems)

            .Where(c => c.Id == id && c.IsDeleted == false).SingleOrDefaultAsync();

            return customer;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var payment = await _context.Customers.Include(c => c.Orders).ThenInclude(c => c.Payment)

            .SingleOrDefaultAsync(c => c.Email == email && c.IsDeleted == false);

            return payment;
        }

        public async Task<IList<Customer>> GetSelectedCustomersAsync(IList<int> ids)
        {
            var customer = await _context.Customers.Include(c => c.Orders).ThenInclude(c => c.Payment)
            
           .Where(c => ids.Contains(c.Id) && c.IsDeleted == false).ToListAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
