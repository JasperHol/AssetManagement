using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.SearchAssetStatus;

public sealed class AssetStatusResponse
{
    public int AssetId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Brand { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
    public string SerialNumber { get; init; } = string.Empty;
    public string? MacAddress { get; init; }
    public string? ServiceTag { get; init; }

    public int StatusId { get; init; }
    public string Status { get; init; } = string.Empty;

    public int AssetUsageId { get; init; }
    public int? PersonId { get; init; }
    public int? LocationId { get; init; }

    public DateTime StartDate { get; init; }
    public DateTime? EndDate { get; init; }

    public int AgreementStatusId { get; init; }
}