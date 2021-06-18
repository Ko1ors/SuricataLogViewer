using LiveCharts;
using LiveCharts.Wpf;
using SuricataLogViewer.ViewModels;
using System.Windows.Controls;

namespace SuricataLogViewer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for EventPieChartUC.xaml
    /// </summary>
    public partial class EventPieChartUC : UserControl
    {
        public EventPieChartUC()
        {
            InitializeComponent();

            DataContext = new PieChartViewModel(Models.PieChartType.Event);
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
    }
}
