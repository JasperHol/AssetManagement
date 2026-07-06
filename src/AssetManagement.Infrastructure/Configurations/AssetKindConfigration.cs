using AssetManagement.Domain.AssetKinds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AssetKindConfiguration : IEntityTypeConfiguration<AssetKind>
{
    public void Configure(EntityTypeBuilder<AssetKind> builder)
    {
        builder.ToTable("AssetKinds");

        builder.HasKey(assetKind => assetKind.Id);

        builder.Property(assetKind => assetKind.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY


        builder.Property(AssetKind => AssetKind.Name)
                .HasMaxLength(200)
                .HasConversion<string>(
                    (Name name) => name.Value,
                    (string value) => new Name(value));

        builder.Property(AssetKind => AssetKind.HasMacAddress)
                .HasConversion<bool>(
                    (HasMacAddress r) => r.Value,
                    (bool v) => new HasMacAddress(v))
                .HasDefaultValueSql("1")
                .IsRequired();

        builder.Property(AssetKind => AssetKind.IsPhysical)
                .HasConversion<bool>(
                    (IsPhysical r) => r.Value,
                    (bool v) => new IsPhysical(v))
                .HasDefaultValueSql("1")
                .IsRequired();



    }
}