
using AssetManagement.Domain.AssetKinds;
using AssetManagement.Domain.AssetTypes;
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

internal sealed class AssetTypeConfiguration : IEntityTypeConfiguration<AssetType>
{
    public void Configure(EntityTypeBuilder<AssetType> builder)
    {
        builder.ToTable("AssetTypes");


        //id
        builder.HasKey(assetType => assetType.Id);

        builder.Property(assetType => assetType.Id)
               .ValueGeneratedOnAdd(); // 👉 tells EF this is IDENTITY

        //Name
        builder.Property(AssetType => AssetType.Name)
                .HasMaxLength(200)
                .HasConversion(name => name.Value, value => new AssetManagement.Domain.AssetTypes.Name(value));

        //Description
        builder.Property(AssetType => AssetType.Description)
                .HasMaxLength(2000)
                .HasConversion(description => description.Value, value => new AssetManagement.Domain.AssetTypes.Description(value));

        //Requestable
        builder.Property(AssetType => AssetType.Requestable)
                .HasConversion(
                r => r.Value,
                v => new AssetManagement.Domain.AssetTypes.Requestable(v))
               .HasDefaultValueSql("1") // 👉 SQL literal, not CLR bool
               .IsRequired();

        //DepreciationValue
        builder.Property(depreciationValue => depreciationValue.DepreciationValue)
                .HasConversion(
                    depreciationValue => depreciationValue.Value,
                    value => new DepreciationValue(value))
                .IsRequired();

        //DepreciationPeriod
        builder.Property(depreciationPeriod => depreciationPeriod.DepreciationPeriod)
                .HasConversion(
                    depreciationPeriod => depreciationPeriod.Value,
                    value => new DepreciationPeriod(value))
                .IsRequired();

        //DataSource
        builder.Property(AssetType => AssetType.DataSource)
                .HasMaxLength(255)
                .HasConversion(dataSource => dataSource.Value, value => new AssetManagement.Domain.AssetTypes.DataSource(value));

        //JiraId
        builder.Property(jiraId => jiraId.JiraId)
                .HasConversion(
                    jiraId => jiraId.Value,
                    value => new JiraId(value))
                .IsRequired();

        //PrefixName
        builder.Property(AssetType => AssetType.PrefixName)
                .HasMaxLength(10)
                .HasConversion(prefixName => prefixName.Value, value => new AssetManagement.Domain.AssetTypes.PrefixName(value));

        //SecuritySensitive
        builder.Property(AssetType => AssetType.SecuritySensitive)
                .HasConversion(
                r => r.Value,
                v => new AssetManagement.Domain.AssetTypes.SecuritySensitive(v))
               .HasDefaultValueSql("0") // 👉 SQL literal, not CLR bool
               .IsRequired();

        //MobileEquipment
        builder.Property(AssetType => AssetType.MobileEquipment)
                .HasConversion(
                r => r.Value,
                v => new AssetManagement.Domain.AssetTypes.MobileEquipment(v))
               .HasDefaultValueSql("0") // 👉 SQL literal, not CLR bool
               .IsRequired();



        builder.Property(assettype => assettype.ModelId)
        .HasConversion(
            id => id.Value,
            value => new ModelId(value))
        .IsRequired(true);

        builder.Property(assettype => assettype.AssetKindId)
        .HasConversion(
            id => id.Value,
            value => new AssetKindId(value))
        .IsRequired(true);

        builder
                .HasOne<Model>()
                .WithMany()
                .HasForeignKey(assettype => assettype.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

         //builder
         //       .HasOne<AssetKind>()
         //       .WithMany()
         //       .HasForeignKey(assettype => assettype.AssetKindId)
         //       .OnDelete(DeleteBehavior.Restrict);

    }
}
