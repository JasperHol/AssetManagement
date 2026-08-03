using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.CreateAssetUsageLocation;
public record CreateAssetUsageLocationCommand(
    int AssetId,
    int LocationId

    )    : ICommand<int>;