using AssetManagement.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.BuildingId)
            .IsRequired();

        builder.Property(x => x.PersonId)
            .IsRequired();

        builder.Property(x => x.ReportingUnitId)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(
                v => v.Value,
                v => new Name(v))
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Remark)
            .HasConversion(
                v => v.Value,
                v => new Remark(v))
            .HasMaxLength(1000);


        builder.Property(location => location.Requestable)
            .HasConversion(
                r => r.Value,
                v => new Requestable(v))
            .HasDefaultValueSql("1") // 👈 SQL literal, not CLR bool
            .IsRequired();
    }
}