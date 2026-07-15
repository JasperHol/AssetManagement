using AssetManagement.Domain.AssetTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AssetTypeRepository(ApplicationDbContext dbContext) : Repository<AssetType>(dbContext), IAssetTypeRepository

{
    public AssetType Update(AssetType assetType)
    {
        DbContext.Set<AssetType>().Update(assetType);
        return assetType;
    }
}