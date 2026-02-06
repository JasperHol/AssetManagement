using AssetManagement.Domain.Abstractions;

namespace AssetManagement.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;