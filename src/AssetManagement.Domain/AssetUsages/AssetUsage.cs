
using global::AssetManagement.Domain.Abstractions;
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
        int assetId,
        int personId,
        int locationId,
        int agreementStatusId,
        StartDate startDate,
        EndDate endDate,
        DataSource dataSource,
        AgreemnentSignDate agreemnentSignDate,
        AgreementDeclineDate agreementDeclineDate,
        AgreementDeclineReason agreementDeclineReason,
        string agreementUsageAgreement,
        int personAssetUsageId

                )
    {
        AssetId = assetId;
        PersonId = personId;
        LocationId = locationId;
        AgreementStatusId = agreementStatusId;
        StartDate = startDate;
        EndDate = endDate;
        DataSource = dataSource;
        AgreemnentSignDate = agreemnentSignDate;
        AgreementDeclineDate = agreementDeclineDate;
        AgreementDeclineReason = agreementDeclineReason;
        AgreementUsageAgreement = agreementUsageAgreement;
        PersonAssetUsageId = personAssetUsageId;

    }

    private AssetUsage()
    {
    }

    public int Id { get; private set; }
    public int AssetId { get; private set; }

    public int PersonId { get; private set; }

    public int LocationId { get; private set; }

    public int AgreementStatusId { get; private set; }
    public StartDate StartDate { get; private set; }
    public EndDate? EndDate { get; private set; }
    public DataSource DataSource { get; private set; }


    public AgreemnentSignDate? AgreemnentSignDate { get; private set; }

    public AgreementDeclineDate? AgreementDeclineDate { get; private set; }

    public AgreementDeclineReason? AgreementDeclineReason { get; private set; }

    public string? AgreementUsageAgreement { get; private set; }

    public int PersonAssetUsageId { get; private set; }


    public static AssetUsage Create(
                int assetId,
        int personId,
        int locationId,
        int agreementStatusId,
        StartDate startDate,
        EndDate endDate,
        DataSource dataSource,
        AgreemnentSignDate agreemnentSignDate,
        AgreementDeclineDate agreementDeclineDate,
        AgreementDeclineReason agreementDeclineReason,
        string agreementUsageAgreement,
        int personAssetUsageId

        )
    {
        var assetUsage = new AssetUsage(
            assetId,
            personId,
            locationId,
            agreementStatusId,
            startDate,
            endDate,
            dataSource,
            agreemnentSignDate,
            agreementDeclineDate,
            agreementDeclineReason,
            agreementUsageAgreement,
            personAssetUsageId
);


        assetUsage.RaiseDomainEvent(
            new AssetUsageCreatedDomainEvent(
                assetUsage.AssetId,
                assetUsage.PersonId,
                assetUsage.LocationId,
                assetUsage.AgreementStatusId,
                assetUsage.StartDate,
                assetUsage.EndDate,
                assetUsage.DataSource,
                assetUsage.AgreemnentSignDate,
                assetUsage.AgreementDeclineDate,
                assetUsage.AgreementDeclineReason,
                assetUsage.AgreementUsageAgreement,
                assetUsage.PersonAssetUsageId
                      ));

        return assetUsage;
    }

    public void End()
    {
        // If EndDate exists and has an actual timestamp that is not MinValue, it's already ended
        if (EndDate?.Value is DateTime existing && existing != DateTime.MinValue)
            throw new InvalidOperationException("AssetUsage has already ended.");
        
        EndDate = new EndDate(DateTime.UtcNow);
        RaiseDomainEvent(new AssetUsageEndedDomainEvent(Id, EndDate));
    }
}





