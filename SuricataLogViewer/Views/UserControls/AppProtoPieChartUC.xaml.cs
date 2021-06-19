using LiveCharts;
using LiveCharts.Wpf;
using SuricataLogViewer.Services;
using SuricataLogViewer.ViewModels;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace SuricataLogViewer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AppProtoPieChartUC.xaml
    /// </summary>
    public partial class AppProtoPieChartUC : UserControl
    {
        public AppProtoPieChartUC()
        {
            InitializeComponent();

            DataContext = new PieChartViewModel(Models.PieChartType.ApplicationProtocol);
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
