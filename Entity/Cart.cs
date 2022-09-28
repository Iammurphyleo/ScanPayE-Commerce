using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Cart : BaseEntity
    {
        public int CustomerId { get; set; }

        public  Customer Customer {get; set;}

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();


    }
}
