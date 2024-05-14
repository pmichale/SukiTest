using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using SukiTest.Common;
using SukiTest.Main;
using SukiTest.Services;

namespace SukiTest;

public partial class App : Application
{
    private IServiceProvider? _provider;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        _provider = ConfigureServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var viewLocator = _provider?.GetRequiredService<IDataTemplate>();
            var mainVm = _provider?.GetRequiredService<MainViewModel>();
            
            desktop.MainWindow = viewLocator?.Build(mainVm) as Window;
            if (desktop.MainWindow != null)
            {
                // desktop.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private static ServiceProvider ConfigureServices()
    {
        var viewLocator = Current?.DataTemplates.First(x => x is ViewLocator);
        var services = new ServiceCollection();

        if (viewLocator is not null)
            services.AddSingleton(viewLocator);
        services.AddSingleton<PageNavigationService>();

        // View models
        services.AddSingleton<MainViewModel>();
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => !p.IsAbstract && typeof(TestPageBase).IsAssignableFrom(p));
        foreach (var type in types)
            services.AddSingleton(typeof(TestPageBase), type);

        return services.BuildServiceProvider();
    }
}