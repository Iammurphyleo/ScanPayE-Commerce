using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();

        public ICollection<PaymentDto> Payments { get; set; } = new List<PaymentDto>();

        public ICollection<CartDto> Carts { get; set; } = new List<CartDto>();


    }

    public class CreateCustomerRequestModel
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

       // public ICollection<OrderDto> OrderDtos { get; set; } = new List<OrderDto>();

       // public ICollection<PaymentDto> PaymentDtos { get; set; } = new List<PaymentDto>();
    }

    public class UpdateCustomerRequestModel
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

       // public ICollection<OrderDto> OrderDtos { get; set; } = new List<OrderDto>();

       // public ICollection<PaymentDto> PaymentDtos { get; set; } = new List<PaymentDto>();
    }

}
