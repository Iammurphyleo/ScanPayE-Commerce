using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class ItemEfConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey("Id");

            builder.Property(i => i.Datecreated).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.ExpiryDate).IsRequired();
            builder.Property(i => i.ItemtName).IsRequired();
            builder.Property(i => i.Price).IsRequired();
            builder.Property(i => i.ManufacturingDate).IsRequired();
            builder.Property(i => i.QrCode).IsRequired();
            builder.Property(i => i.ItemImage).IsRequired();
            builder.HasMany(i => i.ItemOrders).WithOne(i => i.Item).HasForeignKey(i => i.ItemId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(i => i.ItemCategories).WithOne(i => i.Item).HasForeignKey(i => i.ItemId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(i => i.ItemBrands).WithOne(i => i.Item).HasForeignKey(i => i.ItemId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(i => i.ItemStocks).WithOne(i => i.Item).HasForeignKey(i => i.ItemId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
