using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.SearchAssetType;

public sealed class AssetTypeResponse
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string Description { get; init; }

    public bool Requestable { get; init; }
    public int DepreciationValue { get; init; }
    public int DepreciationPeriod { get; init; }
    public string DataSource { get; init; }
    public int JiraId { get; init; }
    public string PrefixName { get; init; }
    public bool SecuritySensitive { get; init; }
    public bool MobileEquipment { get; init; }
    public int ModelId { get; init; }
    public int AssetKindId { get; init; }


}