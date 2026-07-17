using AssetManagement.Domain.Statuses;
using AssetManagement.Domain.StatusTransitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class StatusRepository : Repository<Status>, IStatusRepository

{
    public StatusRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public Status Update(Status Status)
    {
        DbContext.Set<Status>().Update(Status);
        return Status;
    }
}
