using AssetManagement.Domain.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.ToTable("Manufacturers");

        //builder.Property(manufacturer => manufacturer.Id)
        //        .HasConversion(
        //        id => id.Value,
        //        value => new AssetManagement.Domain.Models.ManufacturerId(value))
        //        .ValueGeneratedOnAdd();

        builder.HasKey(manufacturer => manufacturer.Id);

        builder.Property(manufacturer => manufacturer.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY

        builder.Property(manufacturer => manufacturer.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(manufacturer => manufacturer.Description)
                .HasMaxLength(2000)
                .HasConversion(description => description.Value, value => new Description(value));


        builder.Property(manufacturer => manufacturer.Requestable)
                .HasConversion(
                r => r.Value,
                v => new Requestable(v))
               .HasDefaultValueSql("1") // 👈 SQL literal, not CLR bool
               .IsRequired();

    }
}