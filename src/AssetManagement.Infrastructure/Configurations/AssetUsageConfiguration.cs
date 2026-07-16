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
        builder.ToTable("AssetUsages");

        builder.HasKey(assetUsage => assetUsage.Id);

        builder.Property(assetUsage => assetUsage.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY


        builder.Property(assetUsage => assetUsage.StartDate)
            .HasConversion(
                startDate => startDate.Value,
                value => new StartDate(value))
            .HasColumnType("date");
        
        builder.Property(assetUsage => assetUsage.EndDate)
            .HasConversion(
                endDate => endDate.Value,
                value => new EndDate(value))
            .HasColumnType("date");

        builder.Property(AssetUsage => AssetUsage.DataSource)
            .HasMaxLength(200)
            .HasConversion<string>(
                (DataSource dataSource) => dataSource.Value,
                (string value) => new DataSource(value));

        builder.Property(assetUsage => assetUsage.AgreemnentSignDate)
            .HasConversion(
                agreemnentSignDate => agreemnentSignDate.Value,
                value => new AgreemnentSignDate(value))
            .HasColumnType("date");

        builder.Property(assetUsage => assetUsage.AgreementDeclineDate)
            .HasConversion(
                agreementDeclineDate => agreementDeclineDate.Value,
                value => new AgreementDeclineDate(value))
            .HasColumnType("date");

        builder.Property(AssetUsage => AssetUsage.AgreementDeclineReason)
                .HasMaxLength(200)
                .HasConversion<string>(
                    (AgreementDeclineReason agreementDeclineReason) => agreementDeclineReason.Value,
                    (string value) => new AgreementDeclineReason(value));

        builder.Property(x => x.AgreementUsageAgreementImage)
            .HasColumnType("varbinary(max)")
            .IsRequired(false);



    }
}