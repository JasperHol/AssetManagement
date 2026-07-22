using AgreementStatusManagement.Domain.AgreementStatuses;
using AssetManagement.Domain.AgreementStatuses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories;

internal sealed class AgreementStatusRepository : Repository<AgreementStatus>, IAgreementStatusRepository

{
    public AgreementStatusRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
    public AgreementStatus Update(AgreementStatus AgreementStatus)
    {
        DbContext.Set<AgreementStatus>().Update(AgreementStatus);
        return AgreementStatus;
    }
}
