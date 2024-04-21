using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TradingJournal.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Singleton);
        services.AddValidatorsFromAssembly(currentAssembly);
        
        return services;
    }
}