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

        //builder.Property(statusTransition => statusTransition.Id)
        //       .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY

        builder.HasData(
             new { Id = 1, StatusFromId = 1, StatusToId = 6 },
             new { Id = 2, StatusFromId = 1, StatusToId = 3 },
             new { Id = 3, StatusFromId = 2, StatusToId = 3 },
             new { Id = 4, StatusFromId = 2, StatusToId = 4 },
             new { Id = 5, StatusFromId = 2, StatusToId = 6 },
             new { Id = 6, StatusFromId = 2, StatusToId = 5 },
             new { Id = 7, StatusFromId = 3, StatusToId = 5 },
             new { Id = 8, StatusFromId = 3, StatusToId = 2 },
             new { Id = 9, StatusFromId = 3, StatusToId = 4 },
             new { Id = 10, StatusFromId = 4, StatusToId = 6 },
             new { Id = 11, StatusFromId = 4, StatusToId = 2 },
             new { Id = 12, StatusFromId = 4, StatusToId = 3 },
             new { Id = 13, StatusFromId = 5, StatusToId = 8 },
             new { Id = 14, StatusFromId = 5, StatusToId = 6 },
             new { Id = 15, StatusFromId = 5, StatusToId = 3 },
             new { Id = 16, StatusFromId = 5, StatusToId = 2 },
             new { Id = 17, StatusFromId = 6, StatusToId = 7 },
             new { Id = 18, StatusFromId = 6, StatusToId = 2 },
             new { Id = 19, StatusFromId = 6, StatusToId = 4 },
             new { Id = 20, StatusFromId = 6, StatusToId = 5 }
        );



    }
}