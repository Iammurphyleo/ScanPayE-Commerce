using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class UserEfConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey("Id");

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.PhoneNumber).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Address).IsRequired();
           // builder.Property(u => u.Customer).IsRequired();
           // builder.Property(u => u.Staff).IsRequired();
            builder.HasMany(u => u.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.Customer).WithOne(u => u.User).HasForeignKey<Customer>(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.Staff).WithOne(u => u.User).HasForeignKey<Staff>(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
