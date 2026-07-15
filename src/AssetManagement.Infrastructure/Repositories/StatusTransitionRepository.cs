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
}
