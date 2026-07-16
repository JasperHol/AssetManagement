using AssetManagement.Domain.Statuses;
using AssetManagement.Domain.StatusTransitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class StatusTransitionConfiguration : IEntityTypeConfiguration<StatusTransition>
{
    public void Configure(EntityTypeBuilder<StatusTransition> builder)
    {
        builder.ToTable("StatusTransitions");

        builder.HasKey(statusTransition => statusTransition.Id);

        builder.Property(statusTransition => statusTransition.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY


        builder
            .HasOne<Status>()
            .WithMany()
            .HasForeignKey(statusTransition => statusTransition.StatusFromId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne<Status>()
            .WithMany()
            .HasForeignKey(statusTransition => statusTransition.StatusToId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}