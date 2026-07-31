using AssetManagement.Domain.StatusTransitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class StatusTransitionRepository : Repository<StatusTransition>, IStatusTransitionRepository

{
    public StatusTransitionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public StatusTransition Update(StatusTransition StatusTransition)
    {
        DbContext.Set<StatusTransition>().Update(StatusTransition);
        return StatusTransition;
    }

    public interface IStatusTransitionRepository
    {
        Task<bool> IsTransitionAllowedAsync(
            int fromStatusId,
            int toStatusId,
            CancellationToken cancellationToken);
    }
    public async Task<bool> IsTransitionAllowedAsync(
    int fromStatusId,
    int toStatusId,
    CancellationToken cancellationToken)
    {
        return await DbContext.Set<StatusTransition>()
            .AnyAsync(
            x => x.StatusFromId == fromStatusId &&
            x.StatusToId == toStatusId,
            cancellationToken);
    }
}
