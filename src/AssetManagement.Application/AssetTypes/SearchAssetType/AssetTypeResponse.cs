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


}