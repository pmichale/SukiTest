using Material.Icons;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace SukiTest.Common;

public abstract class TestPageBase(string displayName, MaterialIconKind icon, int index = 0) : ReactiveObject
{
    [Reactive] public string DisplayName { get; set; } = displayName;

    [Reactive] public MaterialIconKind Icon { get; private set; } = icon;

    [Reactive] public int Index { get; private set; } = index;
}