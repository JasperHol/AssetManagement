

namespace AssetManagement.Domain.AssetTypes;

public interface IAssetTypeRepository
{
    Task<AssetType?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(AssetType AssetType);

    AssetType Update(AssetType AssetType);

}