using SportsBooking.Application;
using SportsBooking.Infrastructure.Postgres;

namespace SportsBooking.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddWebDependencies();
        
        services.AddApplication();

        services.AddInfrastructure();
        
        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        
        return services;
    }
}