using AssetManagement.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.CreateAssetType;

public record CreateAssetTypeCommand(
    string Name,
    string Description,
    bool Requestable,
    int DepreciationValue,
    int DepreciationPeriod,
    string DataSource,
    int JiraId,
    string PrefixName,
    bool SecuritySensitive,
    bool MobileEquipment,
    int ModelId,
    int AssetKindId
    )
    : ICommand<int>;