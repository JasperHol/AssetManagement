using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Assets.SearchAsset;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Assets.SearchAssetStatus;

internal sealed class SearchAssetStatusQueryHandler
    : IQueryHandler<SearchAssetStatusQuery, IReadOnlyList<AssetStatusResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAssetStatusQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AssetStatusResponse>>> Handle(
        SearchAssetStatusQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        int fromStatusId = request.Id;

        const string sql = """
            SELECT
                Assets.Id AS AssetId,
                Assets.Name,
                Assets.Brand,
                Assets.Model,
                Assets.SerialNumber,
                Assets.MacAddress,
                Assets.ServiceTag,
                Assets.StatusId,

                AssetUsages.Id AS AssetUsageId,
                AssetUsages.PersonId,
                AssetUsages.LocationId,
                AssetUsages.StartDate,
                AssetUsages.EndDate,
                AssetUsages.AgreementStatusId,

                Statuses.Name AS Status
            FROM Assets
            INNER JOIN AssetUsages
                ON Assets.Id = AssetUsages.AssetId
            INNER JOIN Statuses
                ON Assets.StatusId = Statuses.Id
            WHERE AssetUsages.EndDate IS NULL
              AND Assets.StatusId = @fromStatusId
            """;

        var assetStatuses = await connection.QueryAsync<AssetStatusResponse>(
            sql,
            new { fromStatusId });

        return Result.Success<IReadOnlyList<AssetStatusResponse>>(assetStatuses.ToList());
    }
}
