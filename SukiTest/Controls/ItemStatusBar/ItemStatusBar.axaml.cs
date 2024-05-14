using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SukiTest.Controls;

public partial class ItemStatusBar : UserControl
{
    public ItemStatusBar()
    {
        InitializeComponent();
    }

    void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}