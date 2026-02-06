using AssetManagement.Domain.Amenities;


namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AmenityRepository : Repository<Amenity>, IAmenityRepository

{
    public AmenityRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}




