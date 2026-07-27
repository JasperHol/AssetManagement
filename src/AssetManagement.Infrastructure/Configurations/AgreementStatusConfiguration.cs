using AssetManagement.Domain.AgreementStatuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AgreementStatusConfiguration : IEntityTypeConfiguration<AgreementStatus>
{
    public void Configure(EntityTypeBuilder<AgreementStatus> builder)
    {
        builder.ToTable("AgreementStatuses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                name => name.Value,
                value => new Name(value))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IsStartStatus)
            .IsRequired();

        builder.Property(x => x.IsStopStatus)
            .IsRequired();

        builder.HasData(
            new
            {
                Id = 1,
                Name = new Name("NotSignedYet"),
                IsStartStatus = true,
                IsStopStatus = false
            },
            new
            {
                Id = 2,
                Name = new Name("Signed"),
                IsStartStatus = false,
                IsStopStatus = true
            },
            new
            {
                Id = 3,
                Name = new Name("Declined"),
                IsStartStatus = false,
                IsStopStatus = true
            });
    }
}