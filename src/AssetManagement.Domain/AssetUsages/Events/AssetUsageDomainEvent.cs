using AssetManagement.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetUsages.Events;

public sealed record AssetUsageCreatedDomainEvent(
        int AssetId,
        int PersonId,
        int LocationId,
        int AgreementStatusId,
        StartDate StartDate,
        EndDate EndDate,
        DataSource DataSource,
        AgreemnentSignDate AgreemnentSignDate,
        AgreementDeclineDate AgreementDeclineDate,
        AgreementDeclineReason AgreementDeclineReason,
        string AgreementUsageAgreement,
        int PersonAssetUsageId

    ) : IDomainEvent;

public sealed record AssetUsageEndedDomainEvent(
    int AssetUsageId,
    EndDate EndDate)
    : IDomainEvent;

public sealed record AssetUsageSignedDomainEvent(
    int AssetUsageId,
    AgreemnentSignDate AgreemnentSignDate)
    : IDomainEvent;

public sealed record AssetUsageDeclinedDomainEvent(
    int AssetUsageId,
    AgreementDeclineDate AgreementDeclineDate, AgreementDeclineReason AgreementDeclineReason)
    : IDomainEvent;