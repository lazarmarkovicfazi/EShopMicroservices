﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderingDomain.Models;
using OrderingDomain.ValueObjects;

namespace OrderingInfrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(productId => productId.Value,
                           dbId => ProductId.Of(dbId));

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();    
    }
}
