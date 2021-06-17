using LiveCharts;
using LiveCharts.Wpf;
using SuricataLogViewer.Services;
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

            var log = new SuricataService().GetLog();
            var logGrouped = log.GroupBy(e => e.AppProto).ToList();

            SeriesCollection = new SeriesCollection();

            foreach (var group in logGrouped)
            {
                SeriesCollection.Add(new PieSeries
                {
                    Title = group.Key,
                    Values = new ChartValues<int> { group.Count() },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y} ({Math.Round(chartPoint.Participation * 100)}%)",
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#E4E3E3")
            });
            }

            DataContext = this;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        public SeriesCollection SeriesCollection { get; set; }
    }
}
