

namespace AssetManagement.Domain.Amenities;

public interface IAmenityRepository
{
    Task<Amenity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Amenity amenity);

}