using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.EfConfiguration
{
    public class StockEfConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks");
            builder.HasKey("Id");

            builder.Property(s => s.Datecreated).IsRequired();
            builder.Property(s => s.StockName).IsRequired();
            builder.HasMany(s => s.ItemStocks).WithOne(s => s.Stock).HasForeignKey(s => s.StockId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
