using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class BrandEfConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey("Id");

            builder.Property(b => b.BrandName).IsRequired();
           
            builder.Property(b => b.Datecreated).IsRequired();

            
            


        }
    }
}
