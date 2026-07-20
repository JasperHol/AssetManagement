using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Auditing;

internal sealed class AuditLogConfiguration
    : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.EntityName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.EntityId)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Action)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.ChangedBy)
            .HasMaxLength(100);

        builder.Property(x => x.ChangedAtUtc)
            .IsRequired();

        builder.Property(x => x.Changes)
            .HasColumnType("nvarchar(max)")
            .IsRequired();
    }
}