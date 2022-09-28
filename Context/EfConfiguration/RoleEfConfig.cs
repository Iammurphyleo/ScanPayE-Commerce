using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class RoleEfConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey("Id");

            builder.Property(r => r.Datecreated).IsRequired();
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Name).IsRequired();
            builder.HasMany(r => r.UserRoles).WithOne(r => r.Role).HasForeignKey(r => r.RoleId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
