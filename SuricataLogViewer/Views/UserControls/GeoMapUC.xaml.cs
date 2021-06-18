using SuricataLogViewer.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SuricataLogViewer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for GeoMapUC.xaml
    /// </summary>
    public partial class GeoMapUC : UserControl
    {
        public Dictionary<string, double> Values { get; set; }

        public GeoMapUC()
        {
            InitializeComponent();

            Values = new Dictionary<string, double>();
            DataContext = this;

            UpdateMap();
        }

        public Task UpdateMap()
        {
            return Task.Run(() =>
            {
                var log = SuricataService.GetLog();
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
            if(Values.ContainsKey(country))
                Values[country] += 1;
            else
                Values[country] = 1;
        }

    }
}
