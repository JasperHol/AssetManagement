using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.DefaultLocations.SearchDefaultLocation;
internal sealed class SearchDefaultLocationQueryHandler
    : IQueryHandler<SearchDefaultLocationQuery, IReadOnlyList<DefaultLocationResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchDefaultLocationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<DefaultLocationResponse>>> Handle(
        SearchDefaultLocationQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.StatusId AS StatusId,
                a.LocationId AS LocationId,
                a.Description AS Description
            FROM DefaultLocations AS a
            
            """;



        var defaultLocations = await connection.QueryAsync<DefaultLocationResponse>(sql);


        return defaultLocations.ToList();
    }
}
