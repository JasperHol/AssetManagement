using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetUsages.Events;

public sealed record AssetUsageCreatedDomainEvent(
        StartDate StartDate,
        EndDate EndDate,
        DataSource DataSource,
        int AgreementStatus,
        AgreemnentSignDate AgreemnentSignDate,
        AgreementDeclineDate AgreementDeclineDate,
        AgreementDeclineReason AgreementDeclineReason,
        string AgreementUsageAgreementImage,
        int AssetId,
        int PersonId,
        int PersonAssetUsageId,
        int LocationId,
        int AgreementStatusId
    ) : IDomainEvent;

public sealed record AssetUsageEndedDomainEvent(
    int AssetUsageId,
    EndDate EndDate)
    : IDomainEvent;

//public sealed record AssetUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;
