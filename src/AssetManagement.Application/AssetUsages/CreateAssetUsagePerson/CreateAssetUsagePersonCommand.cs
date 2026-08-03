using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.AssetUsages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.CreateAssetUsagePerson;
public record CreateAssetUsagePersonCommand(
    int AssetId,
    int PersonId

    )    : ICommand<int>;