

namespace AssetManagement.Domain.AssetTypes;

public interface IAssetTypeRepository
{
    Task<AssetType?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(AssetType assetType);

    AssetType Update(AssetType assetType);

}