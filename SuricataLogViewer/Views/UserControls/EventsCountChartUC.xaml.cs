using LiveCharts;
using LiveCharts.Wpf;
using SuricataLogViewer.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace SuricataLogViewer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for EventsCountChartUC.xaml
    /// </summary>
    public partial class EventsCountChartUC : UserControl
    {
        public EventsCountChartUC()
        {
            InitializeComponent();

            var log = SuricataService.GetLog();

            if (log is null)
                return;

            var lTime = log.Min(e => e.Timestamp);
            var rTime = log.Max(e => e.Timestamp);
            var timeBetween = rTime - lTime;

            var tCount = 10;
            var t = timeBetween / tCount;

            Labels = new List<string>();
            Values = new ChartValues<double>();

            for (var i = lTime; i <= rTime - t; i += t)
            {
                Labels.Add(i.ToString("dd.MM.yy H:m"));
                Values.Add(log.Where(e => e.Timestamp >= i && e.Timestamp <= i + t).Count());
            }

            DataContext = this;
        }

        public ChartValues<double> Values { get; set; }

        public List<string> Labels { get; set; }

    }
}
