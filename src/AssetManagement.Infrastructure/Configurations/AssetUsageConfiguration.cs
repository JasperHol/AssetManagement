using AssetManagement.Domain.AssetUsages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AssetUsageConfiguration : IEntityTypeConfiguration<AssetUsage>
{
    public void Configure(EntityTypeBuilder<AssetUsage> builder)
    {

        builder.ToTable("AssetsUsage");

        builder.HasKey(assetUsage => assetUsage.Id);

        builder.Property(assetUsage => assetUsage.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY

       builder.Property(x => x.StartDate)
            .HasConversion(
                v => v.Value,
                v => new StartDate(v));

        builder.Property(x => x.EndDate)
            .HasConversion(
                v => v == null ? (DateTime?)null : v.Value,
                v => v == null ? null : new EndDate(v))
            .IsRequired(false);

        builder.Property(x => x.AgreemnentSignDate)
            .HasConversion(
                v => v == null ? (DateTime?)null : v.Value,
                v => v == null ? null : new AgreemnentSignDate(v))
            .IsRequired(false);

        builder.Property(x => x.AgreementDeclineDate)
            .HasConversion(
                v => v == null ? (DateTime?)null : v.Value,
                v => v == null ? null : new AgreementDeclineDate(v))
            .IsRequired(false);

        builder.Property(x => x.AgreementDeclineReason)
            .HasConversion(
                v => v.Value,
                v => new AgreementDeclineReason(v))
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(x => x.DataSource)
            .HasConversion(
                v => v.Value,
                v => new DataSource(v))
            .HasMaxLength(100);
    }
}