
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
        int? personId,
        int? locationId,
        int agreementStatusId,
        StartDate startDate,
        EndDate? endDate,
        DataSource? dataSource,
        AgreementSignDate? agreementSignDate,
        AgreementDeclineDate? agreementDeclineDate,
        AgreementDeclineReason? agreementDeclineReason,
        string? agreementUsageAgreementImage

                )
    {
        AssetId = assetId;
        PersonId = personId;
        LocationId = locationId;
        AgreementStatusId = agreementStatusId;
        StartDate = startDate;
        EndDate = endDate;
        DataSource = dataSource;
        AgreementSignDate = agreementSignDate;
        AgreementDeclineDate = agreementDeclineDate;
        AgreementDeclineReason = agreementDeclineReason;
        AgreementUsageAgreementImage = agreementUsageAgreementImage;


    }

    private AssetUsage()
    {
    }

    public int Id { get; private set; }
    public int AssetId { get; private set; }
    public int? PersonId { get; private set; }
    public int? LocationId { get; private set; }
    public int AgreementStatusId { get; private set; }
    public StartDate StartDate { get; private set; }
    public EndDate? EndDate { get; private set; }
    public DataSource? DataSource { get; private set; }
    public AgreementSignDate? AgreementSignDate { get; private set; }
    public AgreementDeclineDate? AgreementDeclineDate { get; private set; }
    public AgreementDeclineReason? AgreementDeclineReason { get; private set; }
    public string? AgreementUsageAgreementImage { get; private set; }





    public static AssetUsage Create(
        int assetId,
        int? personId,
        int? locationId,
        int agreementStatusId,
        StartDate startDate,
        EndDate? endDate,
        DataSource? dataSource,
        AgreementSignDate? agreementSignDate,
        AgreementDeclineDate? agreementDeclineDate,
        AgreementDeclineReason? agreementDeclineReason,
        string? agreementUsageAgreementImage
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
            agreementSignDate,
            agreementDeclineDate,
            agreementDeclineReason,
            agreementUsageAgreementImage);


        if ((personId.HasValue && locationId.HasValue) || (!personId.HasValue && !locationId.HasValue))
        {
            throw new InvalidOperationException("Exactly one of PersonId or LocationId must be specified.");
        }


        assetUsage.RaiseDomainEvent(
            new AssetUsageCreatedDomainEvent(
                assetUsage.AssetId,
                assetUsage.PersonId,
                assetUsage.LocationId,
                assetUsage.AgreementStatusId,
                assetUsage.StartDate,
                assetUsage.EndDate,
                assetUsage.DataSource,
                assetUsage.AgreementSignDate,
                assetUsage.AgreementDeclineDate,
                assetUsage.AgreementDeclineReason,
                assetUsage.AgreementUsageAgreementImage
                ));

        return assetUsage;
    }

    public void End()
        {
            if (EndDate.Value != DateTime.MinValue)
                throw new InvalidOperationException("Asset usage has already ended.");

            EndDate = new EndDate(DateTime.UtcNow);

            RaiseDomainEvent(new AssetUsageEndedDomainEvent(Id, EndDate));
        }


}





