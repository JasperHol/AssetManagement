using AssetManagement.Domain.AgreementStatuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AgreementStatusConfiguration : IEntityTypeConfiguration<AgreementStatus>
{
    public void Configure(EntityTypeBuilder<AgreementStatus> builder)
    {
        builder.ToTable("AgreementStatus");

        builder.HasKey(x => x.Id);

        //builder.Property(x => x.Id)
        //    .ValueGeneratedOnAdd();
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasConversion(
                v => v.Value,
                v => new Name(v))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IsStartStatus)
            .IsRequired();

        builder.Property(x => x.IsStopStatus)
            .IsRequired();

        builder.HasData(
             AgreementStatus.Create(
                 1,
                 new Name("NotSignedYet"),
                 true,
                 false),

             AgreementStatus.Create(
                 2,
                 new Name("Signed"),
                 false,
                 true),

             AgreementStatus.Create(
                 3,
                 new Name("Declined"),
                 false,
                 true)
        );
        
    }
}