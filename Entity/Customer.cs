using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Payment>  Payments { get; set; } = new List<Payment>();

        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
    
    
    }


}
