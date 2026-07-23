using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Locations.SearchLocation;
internal sealed class SearchLocationQueryHandler
    : IQueryHandler<SearchLocationQuery, IReadOnlyList<LocationResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchLocationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<LocationResponse>>> Handle(
        SearchLocationQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.BuildingId AS BuildingId,
                a.PersonId AS PersonId,
                a.ReportingUnitId AS ReportingUnitId,
                a.Name AS Name,
                a.Remark AS Remark,
                a.Requestable AS Requestable
            FROM Locations AS a
            
            """;



        var locations = await connection.QueryAsync<LocationResponse>(sql);

        //return Result.Success<IReadOnlyList<LocationResponse>>(manufacturers.ToList());

        return locations.ToList();
    }
}
