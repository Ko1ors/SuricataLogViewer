using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using SuricataLogViewer.Models;
using SuricataLogViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SuricataLogViewer.ViewModels
{
    public class PieChartViewModel : BaseViewModel
    {
        private PieChartType type;

        public SeriesCollection SeriesCollection { get; set; }

        public DefaultTooltip DataTooltip { get; set; }

        public PieChartViewModel(PieChartType type)
        {
            this.type = type;
            SeriesCollection = new SeriesCollection();
            DataTooltip = new DefaultTooltip() { SelectionMode = TooltipSelectionMode.OnlySender };
            OnLoad();
            
        }

        public void OnLoad()
        {
            var log = SuricataService.GetLog();
            List<IGrouping<string, Model.SuricataEvent>> logGrouped = null;

            switch (type)
            {
                case PieChartType.Protocol:
                    logGrouped = log.GroupBy(e => e.Proto).ToList();
                    break;
                case PieChartType.ApplicationProtocol:
                    logGrouped = log.GroupBy(e => e.AppProto).ToList();
                    break;
                case PieChartType.Event:
                    logGrouped = log.GroupBy(e => e.EventType).ToList();
                    break;
            }

            foreach (var group in logGrouped)
            {
                SeriesCollection.Add(new PieSeries
                {
                    Title = group.Key,
                    Values = new ChartValues<int> { group.Count() },
                    DataLabels = true,
                    LabelPoint = chartPoint => $"{chartPoint.Y}",
                    FontSize=12,
                    LabelPosition = PieLabelPosition.OutsideSlice,
                    Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#E4E3E3")
                });
            } 
        }
    }
}
