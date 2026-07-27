using AssetManagement.Domain.AgreementStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.AgreementStatuses;


public interface IAgreementStatusRepository
{
    Task<AgreementStatus?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(AgreementStatus agreementStatus);

    AgreementStatus Update(AgreementStatus agreementStatus);

}
