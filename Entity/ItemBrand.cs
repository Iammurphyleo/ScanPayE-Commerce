using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class ItemBrand : BaseEntity
    {
        
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

    }
}
