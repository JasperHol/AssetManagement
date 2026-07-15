

namespace AssetManagement.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(int id)
    {
        Id = id;
    }



    public int Id { get; protected set; }

    protected Entity()
    {
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}

   

//    public static AssetUsage Create(
//        DataSource dataSource,
//        int agreementStatus = 0,
//        int assetId = 0,
//        int personId = 0,
//        int personAssetUsageId = 0,
//        int locationId = 0,
//        int agreementStatusId = 0
//        )
//    {
//        var AssetUsage = new AssetUsage(
//            dataSource,
//            agreementStatus,
//            assetId,
//            personId,
//            personAssetUsageId,
//            locationId,
//            agreementStatusId);


//        AssetUsage.RaiseDomainEvent(
//             new AssetUsageCreatedDomainEvent(
//                  AssetUsage.StartDate,
//                  AssetUsage.EndDate,
//                  AssetUsage.DataSource,
//                  AssetUsage.AgreementStatus,
//                  AssetUsage.AgreemnentSignDate,
//                  AssetUsage.AgreementDeclineDate,
//                  AssetUsage.AgreementDeclineReason,
//                  AssetUsage.AgreementUsageAgreement,
//                  AssetUsage.AssetId,
//                  AssetUsage.PersonId,
//                  AssetUsage.PersonAssetUsageId,
//                  AssetUsage.LocationId,
//                  AssetUsage.AgreementStatusId
//                  ));


//        return AssetUsage;
//    }
//}