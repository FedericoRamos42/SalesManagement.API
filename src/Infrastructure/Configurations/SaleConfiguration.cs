using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Sale");


            builder.Property(s => s.TotalAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(b => b.PaymenthMethod)
                    .HasConversion<string>()
                    .IsRequired();

            builder.Property(b => b.CustomerId)
                    .IsRequired();

            builder.HasOne(s => s.Customer)
                    .WithMany()
                    .HasForeignKey(s=>s.CustomerId);
           

        }
    }
}
