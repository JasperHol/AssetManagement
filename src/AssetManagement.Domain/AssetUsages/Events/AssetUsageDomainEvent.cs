using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetUsages.Events;

public sealed record AssetUsageCreatedDomainEvent(
        int AssetUsage,
        StartDate startDate,
        EndDate endDate,
        DataSource dataSource,
        int agreementStatus,
        AgreemnentSignDate agreemnentSignDate,
        AgreementDeclineDate agreementDeclineDate,
        AgreementDeclineReason agreementDeclineReason,
        byte[] agreementUsageAgreementImage,
        int AssetId,
        int PersonId,
        int PersonAssetUsageId,
        int LocationId,
        int AgreementStatusId
    ) : IDomainEvent;



//public sealed record AssetUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;



//    using AssetManagement.Domain.Abstractions;
//using AssetManagement.Domain.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AssetManagement.Domain.Manufacturers.Events;

//public sealed record ManufacturerCreatedDomainEvent(Name Name, Description Description, Requestable Requestable) : IDomainEvent;
//public sealed record ManufacturerUpdatedDomainEvent(int Id, Requestable Requestable) : IDomainEvent;