using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Category : BaseEntity
    {
       

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();
    }
}
