using Material.Icons;
using SukiTest.Common;

namespace SukiTest.Pages
{
    public class SomeViewModel() : TestPageBase("Some Page", MaterialIconKind.Dog, 2)
    {
        public string OpenedFilePath { get; set; } = "Just a test.";
    }
    
}