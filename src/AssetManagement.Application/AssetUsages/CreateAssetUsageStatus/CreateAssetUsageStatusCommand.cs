using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.AssetUsages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsage.CreateAssetUsageStatus;
public record CreateAssetUsageStatusCommand(
    int AssetId,
    int StatusId

    )    : ICommand<int>;