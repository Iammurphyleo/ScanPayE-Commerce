using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class ItemOrder : BaseEntity
    {
        

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public double UnitWeight { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
