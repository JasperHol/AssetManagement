using AssetManagement.Domain.Abstractions;

namespace AssetManagement.Domain.AssetKinds.Events;

public sealed record AssetKindCreatedDomainEvent(
    
    Name Name,
    HasMacAddress HasMacAddress,
    IsPhysical IsPhysical
) : IDomainEvent;

public sealed record AssetKindPhysicalChangedDomainEvent(
    
    IsPhysical IsPhysical
) : IDomainEvent;

public sealed record AssetKindHasMacAddressChangedDomainEvent(
    
    HasMacAddress HasMacAddress
) : IDomainEvent;