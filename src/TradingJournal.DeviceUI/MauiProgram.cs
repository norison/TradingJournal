using FluentValidation;
using Mediator;
using Microsoft.Extensions.Logging;
using TradingJournal.Application.Abstractions;
using TradingJournal.Application.Behaviors;
using TradingJournal.MemoryPersistence.Implementations;

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
        builder.Services.AddSingleton(typeof(ValidationBehavior<,>), typeof(IPipelineBehavior<,>));
        builder.Services.AddValidatorsFromAssemblies(assemblies, ServiceLifetime.Singleton);
        builder.Services.AddSingleton<IAccountsStorage, AccountsStorage>();
        
        return builder.Build();
    }
}