using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AgreementStatuses;

public sealed class AgreementStatus : Entity
{
    private AgreementStatus(
        int Id,
        Name name,
        bool isStartStatus,
        bool isStopStatus)
    {
        this.Id = Id;
        Name = name;
        IsStartStatus = isStartStatus;
        IsStopStatus = isStopStatus;
    }

    private AgreementStatus()
    {
    }

    public int Id { get; private set; }
    public Name Name { get; private set; }
    public bool IsStartStatus { get; private set; }
    public bool IsStopStatus { get; private set; }

    public static AgreementStatus Create(
        int id,
        Name name,
        bool isStartStatus,
        bool isStopStatus)
    {
        return new AgreementStatus(
            id,
            name,
            isStartStatus,
            isStopStatus);
    }
}