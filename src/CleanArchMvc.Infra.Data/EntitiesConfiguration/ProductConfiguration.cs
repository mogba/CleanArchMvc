﻿using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Price).HasPrecision(10, 2);
            builder.HasOne(t => t.Category).WithMany(t => t.Products).HasForeignKey(t => t.CategoryId);
        }
    }
}
