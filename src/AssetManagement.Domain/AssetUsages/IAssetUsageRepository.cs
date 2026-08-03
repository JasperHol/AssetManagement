using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AssetUsages;

public interface IAssetUsageRepository
{
    Task<AssetUsage?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(AssetUsage assetUsage);

    AssetUsage Update(AssetUsage assetUsage);

    Task<AssetUsage?> GetOpenByAssetIdAsync(int assetId, CancellationToken cancellationToken);

}