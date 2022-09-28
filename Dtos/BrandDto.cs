using Scanpay.Entity;
using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class BrandDto
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();
    }

    public class CreateBrandRequestModel
    {
        public string BrandName { get; set; }

       //public ICollection<Item> ItemDtos { get; set; } = new List<Item>();

        
    }

    public class UpdateBrandRequestModel
    {
        public string BrandName { get; set; }

        //public ICollection<Item> ItemDtos { get; set; } = new List<Item>();
    }
}
