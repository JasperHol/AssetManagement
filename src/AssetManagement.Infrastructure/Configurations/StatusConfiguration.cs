using AssetManagement.Domain.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Statuses");

        builder.HasKey(x => x.Id);

        //builder.Property(x => x.Id)
        //       .ValueGeneratedOnAdd();

        builder.Property(status => status.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, 
            value => new Name(value));


        builder.HasData(
            new { Id = 1, Name = new Name("CreateAsset"), StatusTransitionId = 1 },
            new { Id = 2, Name = new Name("Stock"), StatusTransitionId = 2 },
            new { Id = 3, Name = new Name("InUse"), StatusTransitionId = 3 },
            new { Id = 4, Name = new Name("AssetInServiceRepair"), StatusTransitionId = 4 },
            new { Id = 5, Name = new Name("ReportedStolenMissing"), StatusTransitionId = 5 },
            new { Id = 6, Name = new Name("ObsoleteAsset"), StatusTransitionId = 6 },
            new { Id = 7, Name = new Name("AssetDisposed"), StatusTransitionId = 7 },
            new { Id = 8, Name = new Name("AssetLost"), StatusTransitionId = 8 });
    }
}