using AssetManagement.Domain.DefaultLocations;
using AssetManagement.Domain.Locations;
using AssetManagement.Domain.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class DefaultLocationConfiguration : IEntityTypeConfiguration<DefaultLocation>
{
    public void Configure(EntityTypeBuilder<DefaultLocation> builder)
    {
        builder.ToTable("DefaultLocations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StatusId)
            .IsRequired();

        builder.Property(x => x.LocationId)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasConversion(
                v => v.Value,
                v => new Description(v))
            .HasMaxLength(500)
            .IsRequired();


        builder.HasOne<Status>()
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Location>()
            .WithMany()
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}