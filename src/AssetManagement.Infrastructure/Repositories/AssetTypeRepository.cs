using AssetManagement.Domain.AssetTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AssetTypeRepository : Repository<AssetType>, IAssetTypeRepository

{
    public AssetTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public AssetType Update(AssetType AssetType)
    {
        DbContext.Set<AssetType>().Update(AssetType);
        return AssetType;
    }
}