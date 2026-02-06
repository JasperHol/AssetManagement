

namespace AssetManagement.Domain.Manufacturers;

public interface IManufacturerRepository
{
    Task<Manufacturer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Manufacturer manufacturer);

}