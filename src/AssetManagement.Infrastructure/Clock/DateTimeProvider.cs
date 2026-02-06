using AssetManagement.Application.Abstractions.Clock;

namespace AssetManagement.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}