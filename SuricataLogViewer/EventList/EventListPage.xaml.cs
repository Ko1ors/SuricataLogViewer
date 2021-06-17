using SuricataLogViewer.Model;
using SuricataLogViewer.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SuricataLogViewer.EventList
{
    /// <summary>
    /// Логика взаимодействия для EventListPage.xaml
    /// </summary>
    public partial class EventListPage : Page
    {
        private List<SuricataEvent> events;
        private SuricataService suricataService;

        public EventListPage()
        {
            InitializeComponent();
            suricataService = new SuricataService();
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            events = suricataService.GetLog("https://raw.githubusercontent.com/FrankHassanabad/suricata-sample-data/master/samples/wrccdc-2018/alerts-only.json");
            eventListView.Items.Clear();
            if (events != null)
                foreach (var evt in events)
                {
                    eventListView.Items.Add(new EventUC(evt));
                }

        }
        private void ButtonSearch_Click(object sender, RoutedEventArgs e) { }
    }
}


