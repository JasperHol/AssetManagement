using AssetManagement.Application.Abstractions.Clock;
using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Email;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Models;
using AssetManagement.Domain.AssetTypes;
using AssetManagement.Domain.Users;
using AssetManagement.Infrastructure.Clock;
using AssetManagement.Infrastructure.Data;
using AssetManagement.Infrastructure.Email;
using AssetManagement.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        //services.AddScoped<IUserRepository, UserRepository>();

        //services.AddScoped<IApartmentRepository, ApartmentRepository>();

        //services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();

        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

        services.AddScoped<IModelRepository, ModelRepository>();

        services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();

        //services.AddScoped<IBookingRepository, BookingRepository>();

        //services.AddScoped<IReviewRepository, ReviewRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}