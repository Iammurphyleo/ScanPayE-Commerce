using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Stock : BaseEntity
    {
        public string StockName { get; set; }

        public ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();
    }
}
