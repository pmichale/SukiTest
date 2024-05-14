using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Material.Icons;
using SukiTest.Common;

namespace SukiTest.Pages
{
    public class ChartViewModel : TestPageBase
    {
        public ChartViewModel() : base("Chart Page", MaterialIconKind.ChartBoxOutline, 1)
        {
            
        }
        
        public ISeries[] Series { get; set; } 
            =
            [
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                }
            ];
    }
        
    
}