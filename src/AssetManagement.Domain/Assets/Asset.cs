//using global::AssetManagement.Domain.Abstractions;
//using global::AssetManagement.Domain.Assets;
//using global::AssetManagement.Domain.Assets.Events;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;

//namespace AssetManagement.Domain.Assets;


//public sealed class Asset : Entity
//{

//    private Asset(
//        Name name,
//        Brand brand,
//        Model model)
//    {
//        Name = name;
//        Brand = brand;
//        Model = model;

//    }

//    private Asset()
//    {
//    }

//    public int Id { get; private set; }
//    public Name Name { get; private set; }
//    public Brand Brand { get; private set; } 
//    public Model Model { get; private set; } 

//    public SerialNumber SerialNumber { get; private set; }

//    public MacAddress MacAddress { get; private set; }

//    public ServiceTag ServiceTag { get; private set; }

//    public PurchaseDate PurchaseDate { get; private set; }

//    public OrderNumber OrderNumber { get; private set; }

//    public LostDate LostDate { get; private set; }

//    public DisposedDate DisposedDate { get; private set; }

//    public CmdbLabel CmdbLabel { get; private set; }

//    public DepreciationDate DepreciationDate { get; private set; }

//    public int MsLicenceMappingId { get; private set; }

//    public int StatusId { get; private set; }

//    public AssetManagement.Domain.AssetTypes.AssetTypeId AssetTypeId { get; private set; }


//    //public static Asset Create(
//    //    Name name,
//    //    HasMacAddress? hasMacAddress = null,
//    //    IsPhysical? isPhysical = null)
//    //{
//    //    var Asset = new Asset(
//    //        name,
//    //        hasMacAddress ?? HasMacAddress.True,
//    //        isPhysical ?? IsPhysical.True);

//    //    Asset.RaiseDomainEvent(
//    //        new AssetCreatedDomainEvent(
//    //            Asset.Name,
//    //            Asset.HasMacAddress,
//    //            Asset.IsPhysical));

//    //    return Asset;
//    //}

//    //public void ToggleIsPhysical()
//    //{
//    //    IsPhysical = IsPhysical.Toggle();

//    //    RaiseDomainEvent(
//    //        new AssetPhysicalChangedDomainEvent(

//    //            IsPhysical));
//    //}

   



//}