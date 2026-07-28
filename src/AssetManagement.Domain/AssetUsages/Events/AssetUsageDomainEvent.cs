using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetUsages.Events;

public sealed record AssetUsageCreatedDomainEvent(
        int AssetId,
        int? personId,
        int? locationId   
    ) : IDomainEvent;

public sealed record AssetUsageEndedDomainEvent(
    int AssetUsageId,
    EndDate EndDate)
    : IDomainEvent;

public sealed record AssetUsageSignedDomainEvent(
    int AssetUsageId,
    AgreementSignDate AgreementSignDate)
    : IDomainEvent;

public sealed record AssetUsageDeclinedDomainEvent(
    int AssetUsageId,
    AgreementDeclineDate AgreementDeclineDate)
    : IDomainEvent;

//public sealed record AssetUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;
