using AssetManagement.Application.Abstractions.Clock;
using AssetManagement.Application.Abstractions.Data;
using AssetManagement.Application.Abstractions.Email;
using AssetManagement.Domain.Abstractions;
using AssetManagement.Domain.AssetKinds;
using AssetManagement.Domain.Assets;
using AssetManagement.Domain.AssetTypes;
using AssetManagement.Domain.AssetUsages;
using AssetManagement.Domain.Manufacturers;
using AssetManagement.Domain.Models;
using AssetManagement.Domain.Statuses;
using AssetManagement.Domain.StatusTransitions;
using AssetManagement.Domain.Locations;
using AssetManagement.Domain.Persons;
using AssetManagement.Domain.Users;
using AssetManagement.Infrastructure.Clock;
using AssetManagement.Infrastructure.Data;
using AssetManagement.Infrastructure.Email;
using AssetManagement.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AssetManagement.Domain.AgreementStatuses;

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

        services.AddScoped<IAgreementStatusRepository, AgreementStatusRepository>();

        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

        services.AddScoped<IModelRepository, ModelRepository>();

        services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
        
        services.AddScoped<IAssetKindRepository, AssetKindRepository>();

        services.AddScoped<IAssetRepository, AssetRepository>();

        services.AddScoped<IAssetUsageRepository, AssetUsageRepository>();

        services.AddScoped<IStatusTransitionRepository, StatusTransitionRepository>();

        services.AddScoped<IStatusRepository, StatusRepository>();

        services.AddScoped<IPersonRepository, PersonRepository>();

        services.AddScoped<ILocationRepository, LocationRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}