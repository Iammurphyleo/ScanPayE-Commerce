using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class StockDto
    {
        public int Id { get; set; }

        public string StockName { get; set; }
        
        //public ICollection<ItemDto> ItemStocks { get; set; } = new List<ItemDto>();

    }


    public class CreateStockRequestModel
    {
        public string StockName { get; set; }

       //public ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();
    }

    public class UpdateStockRquestModel
    {
       public string StockName { get; set; }

       // public ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();
    }
}
