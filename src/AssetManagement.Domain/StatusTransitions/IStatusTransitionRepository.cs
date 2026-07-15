using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.StatusTransitions;


public interface IStatusTransitionRepository
{
    Task<StatusTransition?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(StatusTransition model);

    StatusTransition Update(StatusTransition model);

}
