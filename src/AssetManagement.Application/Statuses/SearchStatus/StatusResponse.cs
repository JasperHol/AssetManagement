using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Statuses.SearchStatus;

public sealed class StatusResponse
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;

}
