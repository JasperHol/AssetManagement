using AssetManagement.Domain.Assets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AssetRepository(ApplicationDbContext dbContext) : Repository<Asset>(dbContext), IAssetRepository

{
    public Asset Update(Asset asset)
    {
        DbContext.Set<Asset>().Update(asset);
        return asset;
    }
}