using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SearchAssetUsage;

public sealed class AssetUsageResponse
{
    public int Id { get; init; }
    public int AssetId { get; init; }
    public int PersonId { get; init; }
    public int LocationId { get; init; }
    public int AgreementStatusId { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string DataSource { get; init; }
    public DateTime AgreementSignDate { get; init; }
    public DateTime AgreementDeclineDate { get; init; }
    public string AgreementDeclineReason { get; init; }
    public string AgreementUsageAgreementImage { get; init; }
   


}