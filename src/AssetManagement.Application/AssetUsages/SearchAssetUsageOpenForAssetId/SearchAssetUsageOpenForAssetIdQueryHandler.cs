using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.AssetUsages.SearchAssetUsageOpenForAssetId;

internal sealed class SearchAssetUsagesOpenForAssetIdQueryHandler
    : IQueryHandler<SearchAssetUsageOpenForAssetIdQuery, IReadOnlyList<AssetUsageOpenForAssetIdResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAssetUsagesOpenForAssetIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AssetUsageOpenForAssetIdResponse>>> Handle(
        SearchAssetUsageOpenForAssetIdQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        int fromAssetId = request.Id;

        const string sql = """
            SELECT        
                Assets.Id,
                Assets.Brand, 
                Assets.Name, 
                Assets.Model, 
                Assets.SerialNumber, 
                Assets.MacAddress, 
                Assets.ServiceTag, 
                Assets.OrderNumber, 
                Assets.LostDate, 
                Assets.PurchaseDate, 
                Assets.DisposedDate, 
                Assets.CmdbLabel,
                Assets.DepreciationDate, 
                Assets.MsLicenceMappingId, 
                Assets.StatusId, 
                Assets.AssetTypeId
            FROM            
                Assets 
            INNER JOIN
                AssetUsages ON Assets.Id = AssetUsages.AssetId
            WHERE        
                (AssetUsages.EndDate IS NULL) AND  (AssetUsages.AssetId = @fromAssetId)
            """;

        var AssetUsagesOpenForAssetId = await connection.QueryAsync<AssetUsageOpenForAssetIdResponse>(
            sql,
            new { fromAssetId });

        return AssetUsagesOpenForAssetId.ToList();
    }
}
