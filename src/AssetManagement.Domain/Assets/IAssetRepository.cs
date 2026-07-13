using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Assets;

public interface IAssetRepository
{
    Task<Asset?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Asset asset);

    Asset Update(Asset asset);

}