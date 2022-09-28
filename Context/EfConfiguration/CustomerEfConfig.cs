using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class CustomerEfConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey("Id");

            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Datecreated).IsRequired();
           
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.HasMany(c => c.Orders).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Payments).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerID).OnDelete(DeleteBehavior.Cascade);
           
            

        }
    }
}
