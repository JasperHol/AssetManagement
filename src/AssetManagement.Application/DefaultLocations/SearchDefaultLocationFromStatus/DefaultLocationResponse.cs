using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.SearchDefaultLocationFromStatus;

public sealed class DefaultLocationFromStatusResponse
{
    public int Id { get; init; }
    public int BuildingId { get; init; }
    public int PersonId { get; init; }
    public int ReportingUnitId { get; init; }
    public string Name { get; init; }
    public string Remark { get; init; }
    public bool Requestable { get; init; }

}
