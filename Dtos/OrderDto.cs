using Scanpay.Entity;
using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }

        //public string CustomerFirstName { get; set; }

        //public string CustomerLastName { get; set; }

        // public Payment Payment { get; set; }


        public double TotalWeight { get; set; }

        public DateTime Datecreated { get; set; }

        public decimal TotalPrice { get; set; }

        public string OrderReference { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public bool IsTrue { get; set; }

        public ICollection<ItemDto> Items { get; set; } = new List<ItemDto>();
    }


    public class CreateOrderRequestModel
    {
   

        //public Payment Payment { get; set; }

        //public decimal TotalPrice { get; set; }

       // public DateTime Datecreated { get; set; }

      

     

       // public IEnumerable<Cart> OrderItems { get; set; }

        //public IList<int> ItemId { get; set; } = new List<int>();
    }

    /*public class GetCustomerByNameRequestModel 
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }
    
    }*/

    public class UpdateOrderRequestModel
    {
        //public int CustomerID { get; set; }

        //public Customer Customer { get; set; }

       // public Payment Payment { get; set; }

        //public decimal TotalPrice { get; set; }

        public OrderStatus OrderStatus { get; set; }

       // public ICollection<int> ItemId { get; set; } = new List<int>();
    }
    /*public class Cart
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }
    }*/

}
