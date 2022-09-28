using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();
    }

    public class CreateCategoryRequestModel
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        //public ICollection<Item> Item { get; set; } = new List<Item>();
    }

    public class UpdateCategoryRequestModel
    {

        public string CategoryName { get; set; }

        public string Description { get; set; }

        //public ICollection<Item> ItemDtos { get; set; } = new List<Item>();
    }
}
