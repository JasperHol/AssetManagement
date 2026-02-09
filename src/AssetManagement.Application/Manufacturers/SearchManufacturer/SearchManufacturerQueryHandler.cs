using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Messaging;
using AssetManagement.Domain.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Manufacturers.SearchManufacturer;

internal sealed class SearchManufacturersQueryHandler
    : IQueryHandler<SearchManufacturersQuery, IReadOnlyList<ManufacturerResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchManufacturersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ManufacturerResponse>>> Handle(
        SearchManufacturersQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.Id AS Id,
                a.Name AS Name,
                a.Description AS Description,
                a.Requestable AS Requestable
            FROM Manufacturers AS a
            
            """;



        var manufacturers = await connection.QueryAsync<ManufacturerResponse>(sql);

        //return Result.Success<IReadOnlyList<ManufacturerResponse>>(manufacturers.ToList());

        return manufacturers.ToList();
    }
}
