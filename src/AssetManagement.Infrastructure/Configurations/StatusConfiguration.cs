using AssetManagement.Domain.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;


namespace AssetManagement.Infrastructure.Configurations;

internal sealed class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable("Status");

        builder.HasKey(status => status.Id);

        builder.Property(status => status.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY


        builder.Property(status => status.Name)
            .HasMaxLength(200)
            .HasConversion(status => status.Value, value => new AssetManagement.Domain.Statuses.Name(value));




       




        //builder.HasData(
        //    new
        //    {
        //        Id = 1,
        //        Name = "CreateAsset",
        //        StatusTransitionId = 1
        //    },
        //    new
        //    {
        //        Id = 2,
        //        Name = "Stock",
        //        StatusTransitionId = 2
        //    },

        //    new 
        //    {
        //        Id = 3,
        //        Name = new Name("InUse"),
        //        StatusTransitionId = 3
        //    },

        //    new 
        //    {
        //        Id = 4,
        //        Name = new Name("AssetInServiceRepair"),
        //        StatusTransitionId = 4
        //    },

        //    new 
        //    {
        //        Id = 5,
        //        Name = new Name("ReportedStolenMissing"),
        //        StatusTransitionId = 5
        //    },

        //    new 
        //    {
        //        Id = 6,
        //        Name = new Name("ObsoleteAsset"),
        //        StatusTransitionId = 6
        //    },

        //    new 
        //    {
        //        Id = 7,
        //        Name = new Name("AssetDisposed"),
        //        StatusTransitionId = 7
        //    },

        //    new 
        //    {
        //        Id = 8,
        //        Name = new Name("AssetLost"),
        //        StatusTransitionId = 8
        //    });




       
                    

    }
}