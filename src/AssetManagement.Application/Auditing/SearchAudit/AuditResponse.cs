using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Auditing.SearchAudit;

public sealed class AuditResponse
{
    public int Id { get; init; }

    public string EntityName { get; init; }

    public string Action { get; init; }

    public DateTime ChangedAtUtc { get; init; }
    public string ChangedBy { get; init; }
    public string Changes { get; init; }


}
