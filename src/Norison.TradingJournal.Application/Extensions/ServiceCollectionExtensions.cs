using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;
using Norison.TradingJournal.Application.Behaviors;

namespace Norison.TradingJournal.Application.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Singleton);
        services.AddValidatorsFromAssemblyContaining(typeof(ServiceCollectionExtensions), ServiceLifetime.Singleton);
        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}