using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class CartDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();

        public int ItemQuantity { get; set; }
    }

    public class CreateCartRequestModel 
    {
        public int CustomerId { get; set; }

        public int ItemId { get; set; }

        public int ItemQuantity { get; set; }

        

    }

    public class UpdateCartRequestModel
    {
        public int Id { get; set; }
        public int ItemQuantity { get; set; }
        
    }
}
