using Scanpay.Entity;
using Scanpay.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }

        public int OrderId { get; set; }

        // public string CustomerFirstName { get; set; }

        //public string CustomerLastName { get; set; }

        public string PaymentReference { get; set; }

        public DateTime Datecreated { get; set; }

        public string OrderReference { get; set; }

        public decimal TotalPrice { get; set; }

        //public string PayStackReference { get; set; }

        public PaymentStatus PaymentStatus { get; set; }


    }


    public class CreatePaymentRequestModel
    {
       public int CustomerID { get; set; }

        public int OrderId { get; set; }

        public decimal TotalPrice { get; set; }

        public string OrderReference { get; set; }
    }

    public class Authorizationurl 
    {
        

        public string Url { get; set; }

        
    }


    public class UpdatePaymentRequestModel
    {
      // public int CustomerID { get; set; }

       // public int OrderId { get; set; }

       // public decimal TotalPrice { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }

}

