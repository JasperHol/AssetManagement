
using global::AssetManagement.Domain.Abstractions;
using global::AssetManagement.Domain.AssetUsages;
using global::AssetManagement.Domain.AssetUsages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetUsages;


public sealed class AssetUsage : Entity
{

    private AssetUsage(
        StartDate startDate,
        EndDate endDate,
        DataSource dataSource,
        int agreementStatus,
        AgreemnentSignDate agreemnentSignDate,
        AgreementDeclineDate agreementDeclineDate,
        AgreementDeclineReason agreementDeclineReason,
        byte[] agreementUsageAgreementImage,
        int assetId,
        int personId,
        int personAssetUsageId,
        int locationId,
        int agreementStatusId
                )
    {
        StartDate = startDate;
        EndDate = endDate;
        DataSource = dataSource;
        AgreementStatus = agreementStatus;
        AgreemnentSignDate = agreemnentSignDate;
        AgreementDeclineDate = agreementDeclineDate;
        AgreementDeclineReason = agreementDeclineReason;
        AssetId = assetId;
        PersonId = personId;
        PersonAssetUsageId = personAssetUsageId;
        LocationId = locationId;
        AgreementStatusId = agreementStatusId;

    }

    private AssetUsage()
    {
    }

    public int Id { get; private set; }
    public StartDate StartDate { get; private set; }
    public EndDate EndDate { get; private set; }
    public DataSource DataSource { get; private set; }

    public int AgreementStatus { get; private set; }

    public AgreemnentSignDate AgreemnentSignDate { get; private set; }

    public AgreementDeclineDate AgreementDeclineDate { get; private set; }

    public AgreementDeclineReason AgreementDeclineReason { get; private set; }

    //public AgreementUsageAgreement AgreementUsageAgreement { get; private set; }
    public byte[] AgreementUsageAgreementImage { get; private set; }

    public int AssetId { get; private set; }

    public int PersonId { get; private set; }

    public int PersonAssetUsageId { get; private set; }

    public int LocationId { get; private set; }

    public int AgreementStatusId { get; private set; }
}