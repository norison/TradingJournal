using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace Norison.TradingJournal.WpfDesktop;

public partial class MainWindow
{
    public MainWindow()
    {
        SyncfusionLicenseProvider.RegisterLicense("MzI2MjcyNEAzMjM1MmUzMDJlMzBGakFVTmJhR0hFYitGVFRlQlpxZHd3YXlvNEU0SzZqSWVwT2t1SFFtaHJRPQ==");
        
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddBlazorWebViewDeveloperTools();
        serviceCollection.AddSyncfusionBlazor();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
        
        InitializeComponent();
    }
}