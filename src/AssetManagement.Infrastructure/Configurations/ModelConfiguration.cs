using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models");

        builder.HasKey(model => model.Id);

        builder.Property(model => model.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY

        builder.Property(model => model.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new AssetManagement.Domain.Models.Name(value));

        builder.Property(model => model.Description)
            .HasMaxLength(2000)
            .HasConversion(description => description.Value, value => new AssetManagement.Domain.Models.Description(value));


        builder.Property(model => model.Requestable)
                .HasConversion(
                r => r.Value,
                v => new AssetManagement.Domain.Models.Requestable(v))
               .HasDefaultValueSql("1") // 👈 SQL literal, not CLR bool
               .IsRequired();

        builder.Property(model => model.ManufacturerId)
                .HasConversion(
                    id => id.Value,
                    value => new ManufacturerId(value))
                .IsRequired();

        builder
                .HasOne<Manufacturer>()
                .WithMany()
                .HasForeignKey(model => model.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}