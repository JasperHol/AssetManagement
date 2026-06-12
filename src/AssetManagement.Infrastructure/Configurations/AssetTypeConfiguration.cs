using AssetManagement.Domain.AssetTypes;
using AssetManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AssetTypeConfiguration : IEntityTypeConfiguration<AssetType>
{
    public void Configure(EntityTypeBuilder<AssetType> builder)
    {
        builder.ToTable("AssetTypes");

        
        builder.Property(assetType => assetType.Id)
                .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY

        builder.HasKey(AssetType => AssetType.Id);


        builder.Property(AssetType => AssetType.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.Value, value => new AssetManagement.Domain.AssetTypes.Name(value));

        builder.Property(AssetType => AssetType.Description)
                .HasMaxLength(2000)
                .HasConversion(description => description.Value, value => new AssetManagement.Domain.AssetTypes.Description(value));


        builder.Property(AssetType => AssetType.Requestable)
                .HasConversion(
                r => r.Value,
                v => new AssetManagement.Domain.AssetTypes.Requestable(v))
               .HasDefaultValueSql("1") // 👈 SQL literal, not CLR bool
               .IsRequired();

    }
}