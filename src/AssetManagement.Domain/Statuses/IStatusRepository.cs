using AssetManagement.Domain.Statuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Statuses;

public interface IStatusRepository
{
    Task<Status?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Status status);

    Status Update(Status status);

}