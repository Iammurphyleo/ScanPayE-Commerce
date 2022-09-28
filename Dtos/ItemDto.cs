using Scanpay.Entity;
using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string ItemtName { get; set; }

        public string Description { get; set; }

        public string QrCode { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public decimal Price { get; set; }

        public decimal ItemPrice { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public string ItemImage { get; set; }

        public double ItemWeight { get; set; }

        public string QRCodeImage { get; set; }

        public int CartItemQuantity { get; set; }

        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public ICollection<BrandDto> Brands { get; set; } = new List<BrandDto>();

        //public ICollection<OrderDto> OrderDtos { get; set; } = new List<OrderDto>();

        public ICollection<StockDto> Stocks { get; set; } = new List<StockDto>();

        public ICollection<CartDto>  Carts { get; set; } = new List<CartDto>();


    }


    public class CreateItemRequestModel
    {
        
        public string ItemtName { get; set; }

        public string Description { get; set; }

        //public string QrCode { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        //public ItemStatus ItemStatus { get; set; }

        public decimal Price { get; set; }

        //public string ItemImage { get; set; }

        public double ItemWeight { get; set; }

        //public string QRCodeImage { get; set; }

        public IList<int> CategoryIds { get; set; } = new List<int>();

        public IList<int> BrandIds { get; set; } = new List<int>();

       // public ICollection<int> OrderId { get; set; } = new List<int>();

        public IList<int> StockIds { get; set; } = new List<int>();
    }

    public class UpdateItemRequestModel
    {
       
        public string ItemtName { get; set; }

        public string Description { get; set; }

        //public string QrCode { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }

       // public ItemStatus ItemStatus { get; set; }

        public decimal Price { get; set; }

       // public string ItemImage { get; set; }

        public double ItemWeight { get; set; }

       // public string QRCodeImage { get; set; }

        public ICollection<int> CategoryId { get; set; } = new List<int>();

        public ICollection<int> BrandId { get; set; } = new List<int>();

        //public ICollection<int> OrderId { get; set; } = new List<int>();

        public ICollection<int> StockId { get; set; } = new List<int>();
    }
}
