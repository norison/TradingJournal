using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Norison.TradingJournal.Application.Extensions;
using Norison.TradingJournal.SqlitePersistence;
using Norison.TradingJournal.SqlitePersistence.Extensions;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Norison.TradingJournal.DeviceUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzI2MjcyNEAzMjM1MmUzMDJlMzBGakFVTmJhR0hFYitGVFRlQlpxZHd3YXlvNEU0SzZqSWVwT2t1SFFtaHJRPQ==");

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddApplication();
            builder.Services.AddSqlitePersistence();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            return app;
        }
    }
}
