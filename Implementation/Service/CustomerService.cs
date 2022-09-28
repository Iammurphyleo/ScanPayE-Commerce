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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _customerRepository = customerRepository;

            _userRepository = userRepository;

            _roleRepository = roleRepository;

        }

        public async Task<CustomerDto> AddCustomerAsync(CreateCustomerRequestModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                
            };

            var role = await _roleRepository.GetRoleByNameAsync("Customer");

            
                var userRole = new UserRole
                {
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                };
                user.UserRoles.Add(userRole);
            
            var customer = new Customer 
            { 
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                UserId = user.Id,
                User = user
            };
           var newUser = await _userRepository.CreateUserAsync(user);
           var newCustomer = await _customerRepository.CreateCustomerAsync(customer);
                 
            return new CustomerDto 
            { 
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                Address = newCustomer.Address,
                Email = newCustomer.Email,
                Id = newCustomer.Id,
                PhoneNumber = newCustomer.PhoneNumber
            };


        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
           var customer = await _customerRepository.GetCustomerAsync(id);

            customer.IsDeleted = true;

            await _customerRepository.UpdateCustomerAsync(customer);

            //_customerRepository.DeleteCustomer(customer);

            return true;

        }

        public async Task<IList<CustomerDto>> GetAllCustomersAsync()
        {
            var customer = await _customerRepository.GetAllCustomersAsync();

            var customers = customer.Select(c => new CustomerDto 
            { 
                Address = c.Address,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Id = c.Id,
                PhoneNumber = c.PhoneNumber
            }).ToList();
            return customers;
        }

        public async Task<CustomerDto>  GetCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);

            if (customer == null)
            {
                return null;
            }
            return new CustomerDto
            {
                Address = customer.Address,
                FirstName = customer.FirstName,
                Email = customer.Email,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Id = customer.Id,
                Orders = customer.Orders.Select(o => new OrderDto
                {
                    CustomerID = o.CustomerID,
                    Datecreated = o.Datecreated,
                    Id = o.Id,
                    OrderReference = o.OrderReference,
                    TotalWeight = o.TotalWeight,
                    TotalPrice = o.TotalPrice,
                    OrderStatus = o.OrderStatus

                }).ToList(),

                Carts = customer.Carts.Select(a => new CartDto
                {
                    CustomerId = a.CustomerId,
                    Id = a.Id,
                    
                }).ToList(),

                Payments = customer.Payments.Select(p => new PaymentDto 
                { 
                    CustomerID = p.CustomerID,
                    Id = p.Id,
                    Datecreated =p.Datecreated,
                    OrderId = p.OrderId,
                    TotalPrice = p.TotalPrice,
                    PaymentStatus = p.PaymentStatus,
                    PaymentReference = p.PaymentReference
                    
                }).ToList(),
                
            };
            
        }

        public async Task<CustomerDto> GetCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);

            if (customer == null)
            {
                return null;
            }

            var x = new CustomerDto
            {
                Address = customer.Address,
                FirstName = customer.FirstName,
                Email = customer.Email,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Id = customer.Id,

                Orders = customer.Orders.Select(o => new OrderDto
                {
                    CustomerID = o.CustomerID,
                    Datecreated = o.Datecreated,
                    Id = o.Id,
                    OrderReference = o.OrderReference,
                    TotalWeight = o.TotalWeight,
                    TotalPrice = o.TotalPrice,
                    OrderStatus = o.OrderStatus

                }).ToList(),

                Carts = customer.Carts.Select(a => new CartDto
                {
                    CustomerId = a.CustomerId,
                    Id = a.Id,

                }).ToList(),

                Payments = customer.Payments.Select(p => new PaymentDto
                {
                    CustomerID = p.CustomerID,
                    Id = p.Id,
                    Datecreated = p.Datecreated,
                    OrderId = p.OrderId,
                    TotalPrice = p.TotalPrice,
                    PaymentStatus = p.PaymentStatus,
                    PaymentReference = p.PaymentReference

                }).ToList(),
            };
            return x;
        }

        public async Task<bool> UpdateCustomerAsync(int id ,  UpdateCustomerRequestModel model)
        {
            var customer = await _customerRepository.GetCustomerAsync(id);
            var user = await _userRepository.GetUserAsync(customer.UserId);

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Address = model.Address;

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Password = model.Password;
            user.Address = model.Address;
             
            await _customerRepository.UpdateCustomerAsync(customer);
            await _userRepository.UpdateUserAsync(user);

            return true;

        }
    }
}
