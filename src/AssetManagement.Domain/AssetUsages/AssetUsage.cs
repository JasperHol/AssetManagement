
using AssetManagement.Domain.AgreementStatuses;
using global::AssetManagement.Domain.Abstractions;
using global::AssetManagement.Domain.AssetUsages.Events;
using MediatR;
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

        if ((personId.HasValue && locationId.HasValue) ||
            (!personId.HasValue && !locationId.HasValue))
        {
            throw new InvalidOperationException(
                "Exactly one of PersonId or LocationId must be specified.");
        }

        var _personId = personId == 0 ? (int?)null : personId;
        var _locationId = locationId == 0 ? (int?)null : locationId;

        var assetUsage = new AssetUsage(
            assetId,
            _personId,
            _locationId,
            agreementStatusId,
            new StartDate(DateTime.UtcNow),
            endDate,
            dataSource,
            agreementSignDate,
            agreementDeclineDate,
            agreementDeclineReason,
            agreementUsageAgreementImage
        );

        assetUsage.RaiseDomainEvent(
            new AssetUsageCreatedDomainEvent(
                assetUsage.AssetId,
                assetUsage.PersonId,
                assetUsage.LocationId));

        return assetUsage;
    }

    public void End()
        {
        if (EndDate is not null)
        {
            throw new InvalidOperationException("Asset usage has already ended.");
        }

        EndDate = new EndDate(DateTime.UtcNow);

            RaiseDomainEvent(new AssetUsageEndedDomainEvent(Id, EndDate));
        }

    public void Sign()
    {
        if (EndDate is not null)
        {
            throw new InvalidOperationException("Asset usage has already ended.");
        }

        if (AgreementSignDate is not null)
        {
            throw new InvalidOperationException("Asset usage is already signed.");
        }

        if (AgreementDeclineDate is not null)
        {
            throw new InvalidOperationException("Asset usage is already declined.");
        }

        if (AgreementStatusId != 1)
        {
            throw new InvalidOperationException($"Asset usage has incorrect AgreementStatus. Current AgreementStatusId: {AgreementStatusId}.");
        }

        AgreementSignDate = new AgreementSignDate(DateTime.UtcNow);
        AgreementStatusId = 2;

        RaiseDomainEvent(new AssetUsageSignedDomainEvent(Id, AgreementSignDate));
    }
    public void Decline(string agreementDeclineReason)
    {
        if (EndDate is not null)
        {
            throw new InvalidOperationException("Asset usage has already ended.");
        }

        if (AgreementSignDate is not null)
        {
            throw new InvalidOperationException("Asset usage is already signed.");
        }

        if (AgreementDeclineDate is not null)
        {
            throw new InvalidOperationException("Asset usage is already declined.");
        }

        if (AgreementStatusId != 1)
        {
            throw new InvalidOperationException($"Asset usage has incorrect AgreementStatus. Current AgreementStatusId: {AgreementStatusId}.");
        }

        if (AgreementDeclineReason is null)
        {
            throw new InvalidOperationException($"No decline reason given");
        }


        AgreementDeclineDate = new AgreementDeclineDate(DateTime.UtcNow);
        AgreementStatusId = 3;
        AgreementDeclineReason = new AgreementDeclineReason(agreementDeclineReason);
        RaiseDomainEvent(new AssetUsageDeclinedDomainEvent(Id, AgreementDeclineDate));
    }

}





