using AssetManagement.Domain.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AmenityConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.ToTable("Manufacturers");

        //builder.HasKey(amenity => amenity.Id);

        //builder.Property(amenity => amenity.Name)
        //    .HasMaxLength(200)
        //    .HasConversion(name => name.Value, value => new Name(value));

        //builder.Property(amenity => amenity.Description)
        //    .HasMaxLength(2000)
        //    .HasConversion(description => description.Value, value => new Description(value));

        //builder.Property(amenity => amenity.Number)
        //     .HasConversion(amenity => amenity.Value, value => new Requestable.Create(value).Value);


    }
}