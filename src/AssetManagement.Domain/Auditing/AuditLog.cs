using AssetManagement.Domain.Abstractions;
using System.Text.Json;

namespace AssetManagement.Infrastructure.Auditing;

public sealed class AuditLog : Entity
{
    private AuditLog()
    {
    }

    public int Id { get; private set; }

    public string EntityName { get; private set; } = null!;

    public string EntityId { get; private set; } = null!;

    public string Action { get; private set; } = null!;

    public DateTime ChangedAtUtc { get; private set; }

    public string? ChangedBy { get; private set; }

    public string Changes { get; private set; } = null!;

    public static AuditLog Create(
    string entityName,
    string entityId,
    string action,
    string? changedBy,
    object changes)
    {
        return new AuditLog
        {
            EntityName = entityName,
            EntityId = entityId,
            Action = action,
            ChangedAtUtc = DateTime.UtcNow,
            ChangedBy = changedBy,
            Changes = JsonSerializer.Serialize(changes)
        };
    }
}