using SportsBooking.Application;

namespace SportsBooking.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services.AddWebDependencies();
        
        services.AddApplication();
        
        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        
        return services;
    }
}