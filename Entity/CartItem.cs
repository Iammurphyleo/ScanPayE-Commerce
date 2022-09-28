using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int ItemId { get; set; }
        
        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public double ItemWeigth { get; set; }
    }
}
