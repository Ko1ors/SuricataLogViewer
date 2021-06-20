using SuricataLogViewer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SuricataLogViewer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for GeoMapUC.xaml
    /// </summary>
    public partial class GeoMapUC : UserControl
    {
        public Dictionary<string, double> Values { get; set; }

        public GradientStopCollection GradientStopCollection { get; set; }

        public GeoMapUC()
        {
            InitializeComponent();

            Values = new Dictionary<string, double>();
            GradientStopCollection = new GradientStopCollection()
            {
                new GradientStop()
                {
                    Color = (Color)ColorConverter.ConvertFromString("#84A9AC"),
                    Offset = 0d
                },
                new GradientStop()
                {
                    Color = (Color)ColorConverter.ConvertFromString("#204051"),
                    Offset = 1d
                }
            };

            DataContext = this;

            UpdateMap();
        }

        public Task UpdateMap()
        {
            return Task.Run(() =>
            {
                var log = SuricataService.GetLog();

                if (log is null)
                    return;

                foreach (var suricataEvent in log)
                {
                    IpService.GetIpInfo(suricataEvent);
                    if (!string.IsNullOrEmpty(suricataEvent?.SourceIpInfo.Country))
                        AddToValues(suricataEvent.SourceIpInfo.Country);
                    if (!string.IsNullOrEmpty(suricataEvent?.DestinationIpInfo.Country))
                        AddToValues(suricataEvent.DestinationIpInfo.Country);
                }
            });
        }

        public void AddToValues(string country)
        {
            if (Values.ContainsKey(country))
                Values[country] += 1;
            else
                Values[country] = 1;
        }

    }
}
