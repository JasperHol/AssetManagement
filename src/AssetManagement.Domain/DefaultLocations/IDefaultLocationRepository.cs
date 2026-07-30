using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.DefaultLocations;

public interface IDefaultLocationRepository

{

    

    Task<DefaultLocation?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(DefaultLocation defaultlocation);

    DefaultLocation Update(DefaultLocation defaultlocation);
    Task<bool> ExistsAsync(int statusId, int locationId, CancellationToken cancellationToken);
}