using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class CategoryEfConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey("Id");

            builder.Property(c => c.CategoryName).IsRequired();
            builder.Property(c => c.Datecreated).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.HasMany(c => c.ItemCategories).WithOne(c => c.Category).HasForeignKey(c=>c.CategoryId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
