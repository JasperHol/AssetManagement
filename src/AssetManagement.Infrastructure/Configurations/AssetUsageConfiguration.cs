using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManagement.Domain.AgreementStatuses;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetUsages;
using AssetManagement.Domain.Locations;
using AssetManagement.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AssetUsageConfiguration : IEntityTypeConfiguration<AssetUsage>
{
    public void Configure(EntityTypeBuilder<AssetUsage> builder)
    {
        builder.ToTable("AssetUsages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.AssetId)
           .IsRequired();

        builder.Property(x => x.PersonId);


        builder.Property(x => x.LocationId);


        builder.Property(x => x.AgreementStatusId)
            .IsRequired();


        builder.Property(x => x.StartDate)
            .HasConversion(
                v => v.Value,
                v => new StartDate(v))
            .IsRequired();

        builder.Property(x => x.EndDate)
            .HasConversion(
                v => v.Value,
                v => new EndDate(v));


        builder.Property(x => x.DataSource)
            .HasConversion(
                v => v.Value,
                v => new AssetManagement.Domain.AssetUsages.DataSource(v))
            .HasMaxLength(100);


        builder.Property(x => x.AgreementSignDate)
            .HasConversion(
                v => v.Value,
                v => new AgreementSignDate(v));

        builder.Property(x => x.AgreementDeclineDate)
            .HasConversion(
                v => v.Value,
                v => new AgreementDeclineDate(v));

        builder.Property(x => x.AgreementDeclineReason)
            .HasConversion(
                v => v.Value,
                v => new AgreementDeclineReason(v))
            .HasMaxLength(500);

        builder.Property(x => x.AgreementUsageAgreementImage)
            .HasMaxLength(500);

       


        builder.HasOne<Asset>()
            .WithMany()
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<AgreementStatus>()
            .WithMany()
            .HasForeignKey(x => x.AgreementStatusId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_AssetUsage_PersonOrLocation",
                @"(PersonId IS NOT NULL AND LocationId IS NULL)
          OR
          (PersonId IS NULL AND LocationId IS NOT NULL)");
        });

    }
}