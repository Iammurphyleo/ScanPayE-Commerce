using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{

    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        
        

        public ICollection<ItemBrand> ItemBrands { get; set; } = new List<ItemBrand>();
    }

}
