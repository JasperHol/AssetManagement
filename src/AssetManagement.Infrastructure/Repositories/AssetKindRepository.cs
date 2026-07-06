using AssetManagement.Domain.AssetKinds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AssetKindRepository : Repository<AssetKind>, IAssetKindRepository

{
    public AssetKindRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public AssetKind Update(AssetKind AssetKind)
    {
        DbContext.Set<AssetKind>().Update(AssetKind);
        return AssetKind;
    }
}