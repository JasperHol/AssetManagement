using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.StatusTransitions;


public interface IStatusTransitionRepository
{
    Task<StatusTransition?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(StatusTransition statusTransition);

    StatusTransition Update(StatusTransition statusTransition);

    Task<bool> IsTransitionAllowedAsync(int fromStatusId, int toStatusId, CancellationToken cancellationToken);

}
