using AssetManagement.Domain.Locations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class LocationRepository : Repository<Location>, ILocationRepository

{
    public LocationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public Location Update(Location location)
    {
        DbContext.Set<Location>().Update(location);
        return location;
    }
}