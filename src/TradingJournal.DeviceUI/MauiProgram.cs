using FluentValidation;
using Mediator;
using Microsoft.Extensions.Logging;
using TradingJournal.Application.Behaviors;

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
        
        return builder.Build();
    }
}