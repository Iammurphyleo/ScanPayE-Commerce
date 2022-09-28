using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Item : BaseEntity
    {
         public string ItemtName { get; set; }

        public string Description { get; set; }

        public string QrCode { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public decimal Price { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public string ItemImage { get; set; }

        public double ItemWeight { get; set; }

        public string QrCodeImage { get; set; }

        public ICollection<ItemCategory> ItemCategories { get; set; } = new List<ItemCategory>();

        public ICollection<ItemBrand> ItemBrands { get; set; } = new List<ItemBrand>();

        public ICollection<ItemOrder> ItemOrders { get; set; } = new List<ItemOrder>();

        public ICollection<ItemStock> ItemStocks { get; set; } = new List<ItemStock>();

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        //public Item()
        //{
        //    F
        //}
    }
}
