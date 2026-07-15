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

namespace AssetManagement.Application.Assets.SearchAsset;

internal sealed class SearchAssetsQueryHandler
    : IQueryHandler<SearchAssetQuery, IReadOnlyList<AssetResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAssetsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AssetResponse>>> Handle(
        SearchAssetQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.Brand AS Brand,
                a.Model AS Model,
                a.SerialNumber AS SerialNumber,
                a.MacAddress AS MacAddress,
                a.ServiceTag AS ServiceTag,
                a.PurchaseDate AS PurchaseDate,
                a.OrderNumber AS OrderNumber,
                a.CmdbLabel AS CmdbLabel,
                a.DepreciationDate AS DepreciationDate,
                a.MsLicenceMappingId AS MsLicenceMappingId,
                a.StatusId AS StatusId,
                a.AssetTypeId AS AssetTypeId


            FROM Assets AS a
            
            """;



        var Assets = await connection.QueryAsync<AssetResponse>(sql);

        //return Result.Success<IReadOnlyList<AssetResponse>>(manufacturers.ToList());

        return Assets.ToList();
    }
}
