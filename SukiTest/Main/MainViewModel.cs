using System.Collections.Generic;
using System.Linq;
using Avalonia.Collections;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SukiTest.Common;
using SukiTest.Services;
using SukiTest.Utilities;

namespace SukiTest.Main;

public class MainViewModel : ReactiveObject
{
    public IAvaloniaList<TestPageBase> MenuPages { get; }
    [Reactive] public TestPageBase? ActivePage { get; set; }
    public ReactiveCommand<string, System.Reactive.Unit> OpenUrlCommand { get; }
    
    
    public MainViewModel(IEnumerable<TestPageBase> menuPages, PageNavigationService nav)
    {
        MenuPages = new AvaloniaList<TestPageBase>(menuPages.OrderBy(x => x.Index).ThenBy(x => x.DisplayName));
        
        nav.NavigationRequested += t =>
        {
            var page = MenuPages.FirstOrDefault(x => x.GetType() == t);
            if (page is null || ActivePage?.GetType() == t) return;
            ActivePage = page;
        };
        
        OpenUrlCommand = ReactiveCommand.Create<string>(OpenUrl);
    }
    private static void OpenUrl(string url) => UrlUtilities.OpenUrl(url);
}