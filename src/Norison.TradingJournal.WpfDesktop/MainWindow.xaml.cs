using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;

namespace Norison.TradingJournal.WpfDesktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddBlazorWebViewDeveloperTools();
        serviceCollection.AddSyncfusionBlazor();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
        
        InitializeComponent();
    }
}