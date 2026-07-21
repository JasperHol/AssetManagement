using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.StatusTransitions.SearchNextStatus;

public sealed class NextStatusResponse
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int StatusTransitionId { get; init; }

  

}