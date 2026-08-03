using AssetManagement.Domain.AssetUsages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AssetUsageRepository : Repository<AssetUsage>, IAssetUsageRepository

{
    public AssetUsageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public AssetUsage Update(AssetUsage assetUsage)
    {
        DbContext.Set<AssetUsage>().Update(assetUsage);
        return assetUsage;
    }

    public async Task<AssetUsage?> GetOpenByAssetIdAsync(
    int assetId,
    CancellationToken cancellationToken)
    {
        return await DbContext.Set<AssetUsage>()
            .SingleOrDefaultAsync(
                x => x.AssetId == assetId &&
                     x.EndDate == null,
                cancellationToken);
    }

}