using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetTypes.SearchAssetType;

internal sealed class SearchAssetTypesQueryHandler
    : IQueryHandler<SearchAssetTypesQuery, IReadOnlyList<AssetTypeResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAssetTypesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AssetTypeResponse>>> Handle(
        SearchAssetTypesQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.Description AS Description,
                a.Requestable AS Requestable,
                a.DepreciationValue AS DepreciationValue,
                a.DepreciationPeriod AS DepreciationPeriod,
                a.DataSource AS DataSource,
                a.JiraId AS JiraId,
                a.PrefixName AS PrefixName,
                a.SecuritySensitive AS SecuritySensitive,
                a.MobileEquipment AS MobileEquipment,
                a.ModelId AS ModelId,
                a.AssetKindId AS AssetKindId
            FROM AssetTypes AS a
            
            """;



        var AssetTypes = await connection.QueryAsync<AssetTypeResponse>(sql);

        //return Result.Success<IReadOnlyList<AssetTypeResponse>>(AssetTypes.ToList());

        return AssetTypes.ToList();
    }
}
