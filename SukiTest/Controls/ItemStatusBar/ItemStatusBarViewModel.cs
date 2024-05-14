using System;
using System.Globalization;
using System.Text;
using Avalonia.Data.Converters;
using Material.Icons;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace SukiTest.Controls;

public class ItemConfiguration(string itemName, int itemId)
{
    public string ItemName { get; set; } = itemName;
    public int ItemId { get; set; } = itemId;
}

public class ItemStatusBarViewModel : ReactiveObject
{
    [Reactive] public string ItemName { get; set; }
    [Reactive] public string OpenedFile { get; set; } = "No file opened.";
    [Reactive] public bool IsConnected { get; set; }


    public ItemStatusBarViewModel(ItemConfiguration itemConfiguration)
    {
        ItemName = itemConfiguration.ItemName;
    }
}

public class BoolToConnectionIconConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isConnected)
        {
            return isConnected ? MaterialIconKind.Link : MaterialIconKind.LinkOff;
        }

        return MaterialIconKind.LinkOff; // Default icon fallback
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}