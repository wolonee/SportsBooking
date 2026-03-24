using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SportsBooking.Application.Abstractions;
using SportsBooking.Application.Facilities;
using SportsBooking.Application.Facilities.AddReview;
using SportsBooking.Application.Facilities.CreateFacility;

namespace SportsBooking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<ICommandHandler<Guid, CreateFacilityCommand>, CreateFacilityCommandHandler>();
        services.AddScoped<ICommandHandler<Guid, AddReviewCommand>, AddReviewCommandHandler>();
        
        var assembly = typeof(CreateFacilityCommandHandler).Assembly;
        
        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(ICommandHandler<,>), typeof(ICommandHandler<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
        
        services.Scan(scan => scan.FromAssemblies(assembly)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(IQueryHandler<,>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
        
        return services;
    }
}