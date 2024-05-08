using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Norison.TradingJournal.Application.Extensions;
using Norison.TradingJournal.SqlitePersistence;
using Norison.TradingJournal.SqlitePersistence.Extensions;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Norison.TradingJournal.WpfDesktop;

public partial class MainWindow
{
    public MainWindow()
    {
        SyncfusionLicenseProvider.RegisterLicense(
            "MzI2MjcyNEAzMjM1MmUzMDJlMzBGakFVTmJhR0hFYitGVFRlQlpxZHd3YXlvNEU0SzZqSWVwT2t1SFFtaHJRPQ==");

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddBlazorWebViewDeveloperTools();
        serviceCollection.AddSyncfusionBlazor();

        serviceCollection.AddApplication();
        serviceCollection.AddSqlitePersistence();

        var provider = serviceCollection.BuildServiceProvider();

        provider
            .GetRequiredService<IDbContextFactory<TradingJournalDbContext>>()
            .CreateDbContext()
            .Database.Migrate();

        Resources.Add("services", provider);

        InitializeComponent();
    }
}