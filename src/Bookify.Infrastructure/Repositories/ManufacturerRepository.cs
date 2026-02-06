using AssetManagement.Domain.Manufacturers;


namespace AssetManagement.Infrastructure.Repositories;

internal sealed class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository

{
    public ManufacturerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}