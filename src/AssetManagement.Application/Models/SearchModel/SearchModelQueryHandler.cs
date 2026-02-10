using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Models.SearchModel;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.SearchModel;
internal sealed class SearchModelsQueryHandler
    : IQueryHandler<SearchModelsQuery, IReadOnlyList<ModelResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchModelsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ModelResponse>>> Handle(
        SearchModelsQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.Description AS Description,
                a.Requestable AS Requestable
            FROM Models AS a
            
            """;



        var models = await connection.QueryAsync<ModelResponse>(sql);

        //return Result.Success<IReadOnlyList<ModelResponse>>(manufacturers.ToList());

        return models.ToList();
    }
}
