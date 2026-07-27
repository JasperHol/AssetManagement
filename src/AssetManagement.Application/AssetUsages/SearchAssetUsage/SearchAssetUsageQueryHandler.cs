using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SearchAssetUsage;

internal sealed class SearchAssetUsagesQueryHandler
    : IQueryHandler<SearchAssetUsageQuery, IReadOnlyList<AssetUsageResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAssetUsagesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AssetUsageResponse>>> Handle(
        SearchAssetUsageQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.AssetId AS AssetId,
                a.PersonId AS PersonId,
                a.LocationId AS LocationId,
                a.AgreementStatusId AS AgreementStatusId,
                a.StartDate AS StartDate,
                a.EndDate AS EndDate,
                a.DataSource AS DataSource,
                a.AgreementSignDate AS AgreementSignDate,
                a.AgreementDeclineDate AS AgreementDeclineDate,
                a.AgreementDeclineReason AS AgreementDeclineReason,
                a.AgreementUsageAgreementImage AS AgreementUsageAgreementImage
            FROM AssetUsages AS a
            
            """;



        var AssetUsages = await connection.QueryAsync<AssetUsageResponse>(sql);

        //return Result.Success<IReadOnlyList<AssetUsageResponse>>(AssetUsages.ToList());

        return AssetUsages.ToList();
    }
}
