using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Assets.SearchAssetStatus;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.SearchDefaultLocationFromStatus;
internal sealed class SearchDefaultLocationFromStatusQueryHandler
    : IQueryHandler<SearchDefaultLocationFromStatusQuery, IReadOnlyList<DefaultLocationFromStatusResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchDefaultLocationFromStatusQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<DefaultLocationFromStatusResponse>>> Handle(
        SearchDefaultLocationFromStatusQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        int fromStatusId = request.Id;

        const string sql = """
            SELECT        
                Locations.Id, 
                Locations.BuildingId, 
                Locations.PersonId, 
                Locations.ReportingUnitId, 
                Locations.Name, Locations.Remark
            FROM
                Locations 
            INNER JOIN
                DefaultLocations ON Locations.Id = DefaultLocations.Id
            WHERE (DefaultLocations.StatusId = @fromStatusId)
            """;

        var location = await connection.QueryAsync<DefaultLocationFromStatusResponse>(
            sql,
            new { fromStatusId });

        return Result.Success<IReadOnlyList<DefaultLocationFromStatusResponse>>(location.ToList());
    }
}
