using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SportsBooking.Application.Database;
using SportsBooking.Application.Facilities;
using SportsBooking.Infrastructure.Postgres.Repositories;

namespace SportsBooking.Infrastructure.Postgres;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
        
        services.AddScoped<IFacilitiesRepository, FacilitiesEfCoreRepository>();
        
        return services;
    }
}