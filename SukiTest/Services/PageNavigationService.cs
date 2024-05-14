using SukiTest.Common;
using System;

namespace SukiTest.Services;

public class PageNavigationService
{
    public Action<Type>? NavigationRequested {  get; set; }

    public void RequestNavigation<T>() where T : TestPageBase
    {
        NavigationRequested?.Invoke(typeof(T));
    }
}

