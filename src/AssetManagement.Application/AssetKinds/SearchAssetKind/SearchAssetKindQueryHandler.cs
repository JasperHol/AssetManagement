using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.AssetKinds.SearchAssetKind;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetKinds.SearchAssetKind;
internal sealed class SearchAssetKindsQueryHandler
    : IQueryHandler<SearchAssetKindsQuery, IReadOnlyList<AssetKindResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAssetKindsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AssetKindResponse>>> Handle(
        SearchAssetKindsQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.HasMacAddress AS HasMacAddress,
                a.IsPhysical AS IsPhysical
            FROM AssetKinds AS a
            
            """;



        var AssetKinds = await connection.QueryAsync<AssetKindResponse>(sql);

        //return Result.Success<IReadOnlyList<AssetKindResponse>>(manufacturers.ToList());

        return AssetKinds.ToList();
    }
}
