using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Application.Persons.SearchPerson;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Persons.SearchPerson;
internal sealed class SearchPersonsQueryHandler
    : IQueryHandler<SearchPersonsQuery, IReadOnlyList<PersonResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchPersonsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<PersonResponse>>> Handle(
        SearchPersonsQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.Requestable AS Requestable,
                a.EmailAddress AS EmailAddress,
                a.EmloyeeNumber AS EmloyeeNumber,
                a.DataSource AS DataSource,
                a.Sid AS Sid,
                a.AccountName AS AccountName,
                a.WorksForId AS WorksForId

            FROM Persons AS a
            
            """;



        var persons = await connection.QueryAsync<PersonResponse>(sql);

        //return Result.Success<IReadOnlyList<PersonResponse>>(persons.ToList());

        return persons.ToList();
    }
}
