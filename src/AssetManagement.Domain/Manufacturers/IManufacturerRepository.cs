

namespace AssetManagement.Domain.Manufacturers;

public interface IManufacturerRepository
{
    Task<Manufacturer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Manufacturer manufacturer);

    Manufacturer Update(Manufacturer manufacturer);

}