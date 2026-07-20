using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Auditing.SearchAudit;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Auditing.SearchAudit;
internal sealed class SearchAuditingQueryHandler
    : IQueryHandler<SearchAuditingQuery, IReadOnlyList<AuditResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchAuditingQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<AuditResponse>>> Handle(
        SearchAuditingQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.EntityName AS EntityName,
                a.EntityId AS EntityId,
                a.Action AS Action,
                a.ChangedAtUtc AS ChangedAtUtc,
                a.ChangedBy AS ChangedBy,
                a.Changes AS Changes

            FROM [AuditLogs] AS a
            
            """;



        var models = await connection.QueryAsync<AuditResponse>(sql);

        //return Result.Success<IReadOnlyList<ModelResponse>>(manufacturers.ToList());

        return models.ToList();
    }
}
