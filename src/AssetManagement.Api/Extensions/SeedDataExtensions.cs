//using Bogus;
//using AssetManagement.Application.Abstractions.Data;

//using Dapper;

//namespace AssetManagement.Api.Extensions;

//public static class SeedDataExtensions
//{
//    public static void SeedData(this IApplicationBuilder app)
//    {
//        using var scope = app.ApplicationServices.CreateScope();

//        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
//        using var connection = sqlConnectionFactory.CreateConnection();

//        var faker = new Faker();

//        List<object> apartments = new();
//        for (var i = 0; i < 100; i++)
//        {
//            apartments.Add(new
//            {
//                Id = Guid.NewGuid(),
//                Name = faker.Company.CompanyName(),
//                Description = "Close to the beach",
//                Country = faker.Address.Country(),
//                State = faker.Address.State(),
//                ZipCode = faker.Address.ZipCode(),
//                City = faker.Address.City(),
//                Street = faker.Address.StreetAddress(),
//                PriceAmount = faker.Random.Decimal(50, 1000),
//                PriceCurrency = "USD",
//                CleaningFeeAmount = faker.Random.Decimal(25, 200),
//                CleaningFeeCurrency = "USD",
//                LastBookedOn = DateTime.UtcNow,
//                Version = 1 });
//        }

//        const string sql = """
//            INSERT INTO Apartments
//            (Id, Name, Description,Address_Country, Address_State, Address_ZipCode, Address_City, Address_Street, Price_Amount, Price_Currency, CleaningFee_Amount, CleaningFee_Currency, LastBookedOnUtc, Version)
//            VALUES(@Id, @Name, @Description, @Country, @State, @ZipCode, @City, @Street, @PriceAmount, @PriceCurrency, @CleaningFeeAmount, @CleaningFeeCurrency, @LastBookedOn, @Version);
//            """;

//        connection.Execute(sql, apartments);
//    }
//}
