using AssetManagement.Domain.Manufacturers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository

{
    public ManufacturerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public Manufacturer Update(Manufacturer manufacturer)
    {
        DbContext.Set<Manufacturer>().Update(manufacturer);
        return manufacturer;
    }
}



