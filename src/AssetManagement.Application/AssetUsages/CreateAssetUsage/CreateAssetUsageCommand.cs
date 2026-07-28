using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.AssetUsages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.CreateAssetUsage;
public record CreateAssetUsageCommand(
    int PreviousAssetUsageId,
    int AssetId,
    int PersonId,
    int LocationId

    )    : ICommand<int>;