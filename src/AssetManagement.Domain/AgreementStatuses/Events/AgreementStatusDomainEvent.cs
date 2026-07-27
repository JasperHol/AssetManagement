using AssetManagement.Domain.Abstractions;

namespace AssetManagement.Domain.AgreementStatuses.Events;

public sealed record AgreementStatusCreatedDomainEvent(
    
    Name Name,
    bool IsStartStatus,
    bool IsStopStatus
) : IDomainEvent;

