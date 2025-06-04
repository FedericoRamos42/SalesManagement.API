using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Product");


            builder.Property(p=>p.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasMaxLength(300)
                   .IsRequired();

            builder.Property(p => p.Stock)
                   .IsRequired();

            builder.Property(p => p.CategoryId)
                    .IsRequired();

            

            builder.HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p=>p.CategoryId);    


        }
    }
}
