using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class StaffEfConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs");
            builder.HasKey("Id");

            builder.Property(s => s.FirstName).IsRequired();
            builder.Property(s => s.LastName).IsRequired();
            builder.Property(s => s.Address).IsRequired();
            builder.Property(s => s.Datecreated).IsRequired();
            builder.Property(s => s.Email).IsRequired();
           
            builder.Property(s => s.PhoneNumber).IsRequired();
            builder.Property(s => s.StaffCode).IsRequired();
            
            
        }
    }
}
