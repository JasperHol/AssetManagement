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
        AgreementUsageAgreement agreementUsageAgreement,
        int AssetId,
        int PersonId,
        int PersonAssetUsageId,
        int LocationId,
        int AgreementStatusId
    ) : IDomainEvent
{
    public AssetUsageCreatedDomainEvent(DataSource dataSource, int assetId, int personId, int personAssetUsageId, int locationId, int agreementStatusId)
    {

        DataSource. = dataSource;
        AssetId = assetId;
        PersonId = personId;
        PersonAssetUsageId = personAssetUsageId;
        LocationId = locationId;
        AgreementStatusId = agreementStatusId;
    }
}

//public sealed record AssetUpdatedDomainEvent(int AssetType, Requestable Requestable) : IDomainEvent;
