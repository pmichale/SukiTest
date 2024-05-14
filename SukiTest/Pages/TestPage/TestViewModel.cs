using System.Collections.ObjectModel;
using Material.Icons;
using SukiTest.Common;
using SukiTest.Controls;

namespace SukiTest.Pages
{
    public class TestViewModel : TestPageBase
    {
        
        public ObservableCollection<ItemStatusBarViewModel> StatusBarViewModels { get; }
        
        public TestViewModel() : base("Test Page", MaterialIconKind.TestTube, 3)
        {
            StatusBarViewModels =
            [
                new ItemStatusBarViewModel(new ItemConfiguration("Item 1", 1)),
                new ItemStatusBarViewModel(new ItemConfiguration("Item 2", 2)),
                new ItemStatusBarViewModel(new ItemConfiguration("Item 3", 3)),
                new ItemStatusBarViewModel(new ItemConfiguration("Item 4", 4)),
                new ItemStatusBarViewModel(new ItemConfiguration("Item 5", 5)),
            ];
        }

    }
}