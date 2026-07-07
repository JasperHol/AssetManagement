//using AssetManagement.Application.Abstractions.Data;
//using AssetManagement.Application.Abstractions.Messaging;
//using AssetManagement.Domain.Abstractions;
//using Dapper;


//namespace AssetManagement.Application.Users.SearchUsers;

//internal sealed class SearchUsersQueryHandler : IQueryHandler<SearchUsersQuery, IReadOnlyList<UserResponse>>

//{
//    private readonly ISqlConnectionFactory _sqlConnectionFactory;

//    public SearchUsersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
//    {
//        _sqlConnectionFactory = sqlConnectionFactory;
//    }

//    public async Task<Result<IReadOnlyList<UserResponse>>> Handle(SearchUsersQuery request,CancellationToken cancellationToken)
//    {
//        using var connection = _sqlConnectionFactory.CreateConnection();

//        const string sql = """
//            SELECT
//                id AS Id,
//                first_name AS FirstName,
//                last_name As LastName,
//                email As Email
//            FROM 
//                users
//            WHERE 
//                first_name like @First_Name OR last_name like @Last_Name
//            """;

        

//        var users = await connection.QueryAsync<UserResponse>(
//            sql,
//            new
//            {
//                First_Name = request.First_Name + "%",
//                Last_Name = request.Last_Name + "%"
//            });

//        return Result.Success<IReadOnlyList<UserResponse>>(users.ToList());



//    }
//}





