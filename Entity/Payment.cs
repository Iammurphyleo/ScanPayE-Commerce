using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Payment : BaseEntity
    {
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public decimal TotalPrice { get; set; }

        public string PaymentReference { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        
        //public string PayStackReference { get; set; }

    }
}
