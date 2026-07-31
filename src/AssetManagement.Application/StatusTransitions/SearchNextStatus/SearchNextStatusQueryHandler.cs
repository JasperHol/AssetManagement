using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.StatusTransitions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.StatusTransitions.SearchNextStatus;

internal sealed class SearchNextStatusQueryHandler
    : IQueryHandler<SearchNextStatusQuery, IReadOnlyList<NextStatusResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchNextStatusQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<NextStatusResponse>>> Handle(
        SearchNextStatusQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();



        int fromStatusId = request.Id;

        const string sql = """
            SELECT 
                Statuses.Id,
                Statuses.Name,
                Statuses.StatusTransitionId
            FROM
                Statuses
            INNER JOIN
                StatusTransitions ON Statuses.Id = StatusTransitions.Id
            WHERE
                StatusTransitions.StatusFromId = @FromStatusId
            """;

        var statuses = await connection.QueryAsync<NextStatusResponse>(
            sql,
            new { FromStatusId = fromStatusId });

        return statuses.ToList();

    }
}
