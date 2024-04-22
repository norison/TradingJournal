using FluentValidation;
using Mediator;
using Microsoft.Extensions.Logging;
using TradingJournal.Application.Abstractions.Storages.Accounts;
using TradingJournal.Application.Behaviors;
using TradingJournal.CsvPersistence.Implementations;
using TradingJournal.CsvPersistence.Implementations.Accounts;

namespace TradingJournal.DeviceUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        builder.Services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Singleton);
        builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Singleton);
        builder.Services.AddSingleton<IAccountsStorage, CsvAccountsStorage>();
        
        return builder.Build();
    }
}