using global::AssetManagement.Domain.Abstractions;
using global::AssetManagement.Domain.Assets;
using global::AssetManagement.Domain.Assets.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Assets;


public sealed class Asset : Entity
{

    private Asset(
        Name name,
        Brand brand,
        Model model,
        SerialNumber serialNumber,
        MacAddress macAddress,
        ServiceTag serviceTag,
        PurchaseDate purchaseDate,
        OrderNumber orderNumber,
        LostDate lostDate,
        DisposedDate disposedDate,
        CmdbLabel cmdbLabel,
        DepreciationDate depreciationDate,
        int msLicenceMappingId,
        int statusId,
        int assetTypeId
                )
    {
        Name = name;
        Brand = brand;
        Model = model;
        SerialNumber = serialNumber;
        MacAddress = macAddress;
        ServiceTag = serviceTag;
        PurchaseDate = purchaseDate;
        OrderNumber = orderNumber;
        LostDate = lostDate;
        DisposedDate = disposedDate;
        CmdbLabel = cmdbLabel;
        DepreciationDate = depreciationDate;
        MsLicenceMappingId = msLicenceMappingId;
        StatusId = statusId;
        AssetTypeId = assetTypeId;
    }

    private Asset()
    {
    }

    public int Id { get; private set; }
    public Name Name { get; private set; }
    public Brand Brand { get; private set; }
    public Model Model { get; private set; }

    public SerialNumber SerialNumber { get; private set; }

    public MacAddress MacAddress { get; private set; }

    public ServiceTag ServiceTag { get; private set; }

    public PurchaseDate PurchaseDate { get; private set; }

    public OrderNumber OrderNumber { get; private set; }

    public LostDate LostDate { get; private set; }

    public DisposedDate DisposedDate { get; private set; }

    public CmdbLabel CmdbLabel { get; private set; }

    public DepreciationDate DepreciationDate { get; private set; }

    public int MsLicenceMappingId { get; private set; }

    public int StatusId { get; private set; }

    public int AssetTypeId { get; private set; }


    public static Asset Create(
        Name name,
        Brand brand,
        Model model,
        SerialNumber serialNumber,
        MacAddress macAddress,
        ServiceTag serviceTag,
        PurchaseDate purchaseDate,
        OrderNumber orderNumber,
        LostDate lostDate,
        DisposedDate disposedDate,
        CmdbLabel cmdbLabel,
        DepreciationDate depreciationDate,
        int msLicenceMappingId = 0,
        int statusId = 0,
        int assetTypeId = 0)
    {
        var Asset = new Asset(
            name,
            brand,  
            model,
            serialNumber,
            macAddress,
            serviceTag,
            purchaseDate,
            orderNumber,
            lostDate, 
            disposedDate,
            cmdbLabel, 
            depreciationDate,
            msLicenceMappingId, 
            statusId,
            assetTypeId);


        Asset.RaiseDomainEvent(
            new AssetCreatedDomainEvent(
                 Asset.Id,
                 Asset.Name,
                 Asset.Brand,
                 Asset.Model,
                 Asset.SerialNumber,
                 Asset.MacAddress,
                 Asset.ServiceTag,
                 Asset.PurchaseDate,
                 Asset.OrderNumber,
                 Asset.LostDate,
                 Asset.DisposedDate,
                 Asset.CmdbLabel,
                 Asset.DepreciationDate,
                 Asset.MsLicenceMappingId,
                 Asset.StatusId,
                 Asset.AssetTypeId
                 ));


        return Asset;
    }

   
}