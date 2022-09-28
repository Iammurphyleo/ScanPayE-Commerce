using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Order : BaseEntity
    {
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
        
        public Payment Payment { get; set; }

        public decimal TotalPrice { get; set; }

        public double TotalWeight { get; set; }

        public string OrderReference { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ICollection<ItemOrder> ItemOrders { get; set; } = new List<ItemOrder>();
    }
}
