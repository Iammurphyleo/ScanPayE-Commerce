using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class OrderEfConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey("Id");

            builder.Property(o => o.CustomerID).IsRequired();
            builder.Property(o => o.Datecreated).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired();
            builder.HasOne(o => o.Payment).WithOne(o => o.Order).HasForeignKey<Payment>(o => o.OrderId).OnDelete(DeleteBehavior.Cascade);
           
            builder.HasMany(o => o.ItemOrders).WithOne(o => o.Order).HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Cascade);
            


        }
    }
}
