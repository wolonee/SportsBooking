using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SportsBooking.Application.Facilities;

namespace SportsBooking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        
        services.AddScoped<IFacilitiesService, FacilitiesService>();
        
        return services;
    }
}