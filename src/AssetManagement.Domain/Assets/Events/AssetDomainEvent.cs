using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Assets.Events;
public sealed record AssetCreatedDomainEvent(int asset, Name name,
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
        DepreciationDate depreciationDate) : IDomainEvent;

//public sealed record AssetUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;
