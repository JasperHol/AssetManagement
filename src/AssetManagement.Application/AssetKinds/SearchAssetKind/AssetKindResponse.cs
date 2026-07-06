using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetKinds.SearchAssetKind;

public sealed class AssetKindResponse
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string HasMacAddress { get; init; }

    public bool IsPhysical { get; init; }


}
