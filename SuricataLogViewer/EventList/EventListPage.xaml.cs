using SuricataLogViewer.Model;
using SuricataLogViewer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace SuricataLogViewer.EventList
{
    /// <summary>
    /// Логика взаимодействия для EventListPage.xaml
    /// </summary>
    public partial class EventListPage : Page
    {
        private List<SuricataEvent> events;
        private SuricataService suricataService;

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(EventListPage));
        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(EventListPage));

        public ObservableCollection<EventUC> EventUCCollection { get; set; }

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public EventListPage()
        {
            InitializeComponent();
            suricataService = new SuricataService();
            EventUCCollection = new ObservableCollection<EventUC>();
            var lockObj = new object();

            HeaderText = "Events";
            BindingOperations.EnableCollectionSynchronization(EventUCCollection, lockObj);
            DataContext = this;
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                events = suricataService.GetLog("https://raw.githubusercontent.com/FrankHassanabad/suricata-sample-data/master/samples/wrccdc-2018/alerts-only.json");
                fillEventListView(events.OrderByDescending(u => u.Timestamp).ToList());
            });
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                if (events == null) { MessageBox.Show("Error"); return; }
                FilterData fd = null;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    fd = createFilterData();
                })).Wait();
                if (fd == null) return;
                List<SuricataEvent> filteredEvents = events.Where(u =>
                {
                    if (!fd.timestamp.Equals(fd.testTimestamp))
                    {
                        if (fd.сomparisonStateTimestamp == СomparisonState.Less && fd.timestamp > u.Timestamp) return false;
                        if (fd.сomparisonStateTimestamp == СomparisonState.More && fd.timestamp < u.Timestamp) return false;
                        if (fd.сomparisonStateTimestamp == СomparisonState.Empty && !fd.timestamp.Equals(u.Timestamp)) return false;
                    }
                    if (fd.flowId != null)
                    {
                        if (fd.сomparisonStateFlowId == СomparisonState.Less && Convert.ToUInt64(fd.flowId) > Convert.ToUInt64(u.FlowId.ToString())) return false;
                        if (fd.сomparisonStateFlowId == СomparisonState.More && Convert.ToUInt64(fd.flowId) < Convert.ToUInt64(u.FlowId.ToString())) return false;
                        if (fd.сomparisonStateFlowId == СomparisonState.Empty && !fd.flowId.Equals(u.FlowId.ToString())) return false;
                    }
                    if (fd.listEventType.Count != 0)
                    {
                        if (!fd.listEventType.Contains(u.EventType)) return false;
                    }
                    if (fd.SrcIp != null)
                    {
                        if (!fd.SrcIp.Equals(u.SrcIp)) return false;
                    }
                    if (fd.DestIp != null)
                    {
                        if (!fd.DestIp.Equals(u.DestIp)) return false;
                    }
                    if (fd.listProto.Count != 0)
                    {
                        if (!fd.listProto.Contains(u.Proto)) return false;
                    }
                    if (fd.listAppProto.Count != 0)
                    {
                        if (!fd.listAppProto.Contains(u.AppProto)) return false;
                    }
                    return true;
                }).ToList();
                fillEventListView(filteredEvents);
            });
        }
        void EventUC_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EventUC ev = (EventUC)sender;
            SuricataEvent suricataEvent = (SuricataEvent)ev.DataContext;
            ViewEl viewEl = new ViewEl(suricataEvent);
            viewEl.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            StackPanel stackPanel = (StackPanel)btn.Parent;
            clearFilters(stackPanel);
        }

        private void Button_ClearAllFilters(object sender, RoutedEventArgs e)
        {
            string stackPanelName = "stackPanel";
            for (int i = 1; i < 10; i++)
            {
                clearFilters((StackPanel)this.FindName(stackPanelName + i));
            }
        }

        private void clearFilters(StackPanel stackPanel)
        {
            var textBox = stackPanel.Children.OfType<TextBox>().ToList();
            foreach (var tb in textBox)
                tb.Text = "";

            var checkBox = stackPanel.Children.OfType<CheckBox>().ToList();
            foreach (var cb in checkBox)
                cb.IsChecked = false;

            try
            {
                var nestedStackPanel = stackPanel.Children.OfType<StackPanel>().ToList()[0];
                var listCheckBox = nestedStackPanel.Children.OfType<CheckBox>().ToList();
                foreach (var check in listCheckBox)
                {
                    check.IsChecked = false;
                }
            }
            catch { }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox)
            {
                var cb = sender as CheckBox;
                StackPanel stackPanel = (StackPanel)cb.Parent;
                var list = stackPanel.Children.OfType<CheckBox>().ToList();
                foreach (var check in list)
                {
                    if ((bool)cb.IsChecked && !cb.Equals(check)) check.IsChecked = false;
                }
            }
        }
        private void fillEventListView(List<SuricataEvent> events)
        {
            EventUCCollection.Clear();
            if (events != null)
                foreach (var evt in events)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        EventUC eventUC = new EventUC(evt);
                        eventUC.MouseLeftButtonUp += new MouseButtonEventHandler(EventUC_MouseLeftButtonUp);
                        EventUCCollection.Add(eventUC);
                    }));
                }
            Dispatcher.BeginInvoke(new Action(() =>
            {
                IsExpanded = false;
                HeaderText = "Events (Current count: " + events.Count + ")";
            }));
        }

        private FilterData createFilterData()
        {
            DateTime timestamp = new DateTime();
            string flowId = null;
            string srcIp = null;
            string destIp = null;
            string cProto;
            string cAppProto;
            try
            {
                if (!customTimestamp.Text.Trim().Equals("")) timestamp = Convert.ToDateTime(customTimestamp.Text.Trim());
                if (!customFlowId.Text.Trim().Equals(""))
                {
                    flowId = customFlowId.Text.Trim();
                    Convert.ToUInt64(flowId);
                }
                if (!customSrcIp.Text.Trim().Equals("")) srcIp = customSrcIp.Text.Trim();
                if (!customDestIp.Text.Trim().Equals("")) destIp = customDestIp.Text.Trim();
                cProto = customProto.Text.Trim();
                cAppProto = customAppProto.Text.Trim();
            }
            catch
            {
                MessageBox.Show("Invalid value of filter!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            СomparisonState сomparisonStateTimestamp = СomparisonState.Empty;
            if ((bool)checkBoxTimestamp1.IsChecked) сomparisonStateTimestamp = СomparisonState.Less;
            if ((bool)checkBoxTimestamp2.IsChecked) сomparisonStateTimestamp = СomparisonState.More;

            СomparisonState сomparisonStateFlowId = СomparisonState.Empty;
            if ((bool)checkBoxFlowId1.IsChecked) сomparisonStateFlowId = СomparisonState.Less;
            if ((bool)checkBoxFlowId2.IsChecked) сomparisonStateFlowId = СomparisonState.More;

            List<string> listEventType = new List<string>();
            if ((bool)checkBoxEventType1.IsChecked) listEventType.Add(checkBoxEventType1.Content.ToString());
            if ((bool)checkBoxEventType2.IsChecked) listEventType.Add(checkBoxEventType2.Content.ToString());
            if ((bool)checkBoxEventType3.IsChecked) listEventType.Add(checkBoxEventType3.Content.ToString());
            if ((bool)checkBoxEventType4.IsChecked) listEventType.Add(checkBoxEventType4.Content.ToString());
            if ((bool)checkBoxEventType5.IsChecked) listEventType.Add(checkBoxEventType5.Content.ToString());
            if ((bool)checkBoxEventType6.IsChecked) listEventType.Add(checkBoxEventType6.Content.ToString());
            if ((bool)checkBoxEventType7.IsChecked) listEventType.Add(checkBoxEventType7.Content.ToString());

            List<string> listProto = new List<string>();
            if (!cProto.Equals("")) listProto.Add(cProto);
            if ((bool)checkBoxProto1.IsChecked) listProto.Add(checkBoxProto1.Content.ToString());
            if ((bool)checkBoxProto2.IsChecked) listProto.Add(checkBoxProto2.Content.ToString());

            List<string> listAppProto = new List<string>();
            if (!cAppProto.Equals("")) listAppProto.Add(cAppProto);
            if ((bool)checkBoxAppProto1.IsChecked) listAppProto.Add(checkBoxAppProto1.Content.ToString());
            if ((bool)checkBoxAppProto2.IsChecked) listAppProto.Add(checkBoxAppProto2.Content.ToString());
            if ((bool)checkBoxAppProto3.IsChecked) listAppProto.Add(checkBoxAppProto3.Content.ToString());
            if ((bool)checkBoxAppProto4.IsChecked) listAppProto.Add(checkBoxAppProto4.Content.ToString());
            if ((bool)checkBoxAppProto5.IsChecked) listAppProto.Add(checkBoxAppProto5.Content.ToString());
            if ((bool)checkBoxAppProto6.IsChecked) listAppProto.Add(checkBoxAppProto6.Content.ToString());
            return new FilterData(timestamp, сomparisonStateTimestamp, flowId, сomparisonStateFlowId, listEventType, srcIp, destIp, listProto, listAppProto);
        }

        enum СomparisonState
        {
            Empty = 0,
            Less,
            More
        }

        private class FilterData
        {
            public DateTime timestamp;
            public СomparisonState сomparisonStateTimestamp;
            public string flowId;
            public СomparisonState сomparisonStateFlowId;
            public List<string> listEventType;
            public string SrcIp;
            public string DestIp;
            public List<string> listProto;
            public List<string> listAppProto;
            public DateTime testTimestamp = new DateTime();
            public FilterData(DateTime timestamp, СomparisonState сomparisonStateTimestamp, string flowId, СomparisonState сomparisonStateFlowId,
                List<string> listEventType, string srcIp, string destIp, List<string> listProto, List<string> listAppProto)
            {
                this.timestamp = timestamp;
                this.сomparisonStateTimestamp = сomparisonStateTimestamp;
                this.flowId = flowId;
                this.сomparisonStateFlowId = сomparisonStateFlowId;
                this.listEventType = listEventType;
                SrcIp = srcIp;
                DestIp = destIp;
                this.listProto = listProto;
                this.listAppProto = listAppProto;
            }
        }
    }
}


