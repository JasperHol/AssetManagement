using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Statuses.SearchStatus;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Statuses.SearchStatus;
internal sealed class SearchStatusesQueryHandler
    : IQueryHandler<SearchStatusesQuery, IReadOnlyList<StatusResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchStatusesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<StatusResponse>>> Handle(
        SearchStatusesQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name
            FROM Statuses AS a
            
            """;



        var models = await connection.QueryAsync<StatusResponse>(sql);


        return models.ToList();
    }
}
