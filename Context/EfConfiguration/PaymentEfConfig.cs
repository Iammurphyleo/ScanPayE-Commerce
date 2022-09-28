using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class PaymentEfConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");
            builder.HasKey("Id");

            builder.Property(p => p.CustomerID).IsRequired();
            builder.Property( p=> p.Datecreated).IsRequired();
            builder.Property(p => p.TotalPrice).IsRequired();
            builder.Property(p => p.OrderId).IsRequired();
            
            

        }
    }
}
