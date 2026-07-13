using AssetManagement.Domain.AssetTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetKinds;

public interface IAssetKindRepository
{
    Task<AssetKind?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(AssetKind assetKind);

    AssetKind Update(AssetKind assetKind);

}