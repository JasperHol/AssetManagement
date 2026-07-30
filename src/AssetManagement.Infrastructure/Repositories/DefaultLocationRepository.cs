using AssetManagement.Domain.DefaultLocations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class DefaultLocationRepository : Repository<DefaultLocation>, IDefaultLocationRepository

{
    public DefaultLocationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public DefaultLocation Update(DefaultLocation defaultlocation)
    {
        DbContext.Set<DefaultLocation>().Update(defaultlocation);
        return defaultlocation;
    }


    public async Task<bool> ExistsAsync(
        int statusId,
        int locationId,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<DefaultLocation>()
            .AnyAsync(
                x => x.StatusId == statusId &&
                     x.LocationId == locationId,
                cancellationToken);
    }




}