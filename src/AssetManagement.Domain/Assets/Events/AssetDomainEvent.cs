using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Assets.Events;
public sealed record AssetCreatedDomainEvent(int Asset, 
        Name Name,
        Brand Brand,
        Model Model,
        SerialNumber SerialNumber,
        MacAddress MacAddress,
        ServiceTag ServiceTag,
        PurchaseDate PurchaseDate,
        OrderNumber OrderNumber,
        LostDate LostDate,
        DisposedDate DisposedDate,
        CmdbLabel CmdbLabel,
        DepreciationDate DepreciationDate,
        int MsLicenceMappingId, 
        int StatusId,
        int AsetTypeId) : IDomainEvent;

//public sealed record AssetUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;
