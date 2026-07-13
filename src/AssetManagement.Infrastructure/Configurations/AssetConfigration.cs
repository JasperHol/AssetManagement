using AssetManagement.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.ToTable("Assets");

        builder.HasKey(asset => asset.Id);

        builder.Property(asset => asset.Id)
               .ValueGeneratedOnAdd(); // 👈 tells EF this is IDENTITY


        builder.Property(asset => asset.Name)
                .HasMaxLength(200)
                .HasConversion<string>(
                    (Name name) => name.Value,
                    (string value) => new Name(value));

        builder.Property(asset => asset.Brand)
               .HasMaxLength(200)
               .HasConversion<string>(
                   (Brand brand) => brand.Value,
                   (string value) => new Brand(value));

        builder.Property(asset => asset.Model)
            .HasMaxLength(200)
            .HasConversion<string>(
                (Model model) => model.Value,
                (string value) => new Model(value));
        
        builder.Property(Asset => Asset.SerialNumber)
        .HasMaxLength(200)
        .HasConversion<string>(
            (SerialNumber serialNumber) => serialNumber.Value,
            (string value) => new SerialNumber(value));
        
        builder.Property(Asset => Asset.MacAddress)
        .HasMaxLength(200)
        .HasConversion<string>(
            (MacAddress macAddress) => macAddress.Value,
            (string value) => new MacAddress(value));
        
        builder.Property(Asset => Asset.ServiceTag)
        .HasMaxLength(200)
        .HasConversion<string>(
            (ServiceTag serviceTag) => serviceTag.Value,
            (string value) => new ServiceTag(value));
        
        builder.Property(asset => asset.PurchaseDate)
            .HasConversion(
                purchaseDate => purchaseDate.Value,
                value => new PurchaseDate(value))
            .HasColumnType("date");

        builder.Property(Asset => Asset.OrderNumber)
        .HasMaxLength(200)
        .HasConversion<string>(
            (OrderNumber orderNumber) => orderNumber.Value,
            (string value) => new OrderNumber(value));

        builder.Property(asset => asset.LostDate)
            .HasConversion(
                lostDate => lostDate.Value,
                value => new LostDate(value));

        builder.Property(asset => asset.DisposedDate)
            .HasConversion(
                disposedDate => disposedDate.Value,
                value => new DisposedDate(value));

        builder.Property(Asset => Asset.CmdbLabel)
        .HasMaxLength(200)
        .HasConversion<string>(
            (CmdbLabel cmdbLabel) => cmdbLabel.Value,
            (string value) => new CmdbLabel(value));
        
        builder.Property(asset => asset.DepreciationDate)
            .HasConversion(
                depreciationDate => depreciationDate.Value,
                value => new DepreciationDate(value));

        builder
           .HasOne<Asset>()
           .WithMany()
           .HasForeignKey(asset => asset.AssetTypeId)
           .OnDelete(DeleteBehavior.Restrict);

    }
}