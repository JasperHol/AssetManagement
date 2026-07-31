using AssetManagement.Domain.DefaultLocations;
using AssetManagement.Infrastructure;
using AssetManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

internal sealed class DefaultLocationRepository
    : Repository<DefaultLocation>, IDefaultLocationRepository
{
    public DefaultLocationRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public DefaultLocation Update(DefaultLocation defaultlocation)
    {
        DbContext.Set<DefaultLocation>().Update(defaultlocation);
        return defaultlocation;
    }

    public async Task<bool> StatusIdExistsAsync(
    int statusId,
    CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<DefaultLocation>()
            .AnyAsync(
                x => x.StatusId == statusId,
                cancellationToken);
    }
    
    public async Task<bool> LocationIdExistsAsync(
    int locationId,
    CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<DefaultLocation>()
            .AnyAsync(
                x => x.LocationId == locationId,
                cancellationToken);
    }

    public async Task<DefaultLocation?> GetByStatusIdAsync(
        int statusId,
        CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<DefaultLocation>()
            .FirstOrDefaultAsync(
                x => x.StatusId == statusId,
                cancellationToken);
    }
}