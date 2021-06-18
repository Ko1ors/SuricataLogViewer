﻿using SuricataLogViewer.Model;
using SuricataLogViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        public EventListPage()
        {
            InitializeComponent();
            suricataService = new SuricataService();
        }

        private void ButtonShowAll_Click(object sender, RoutedEventArgs e)
        {
            events = suricataService.GetLog("https://raw.githubusercontent.com/FrankHassanabad/suricata-sample-data/master/samples/wrccdc-2018/alerts-only.json");
            fillEventListView(events);
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (events == null) MessageBox.Show("Error");
            FilterData fd = createFilterData();
            List<SuricataEvent> filteredEvents = events.Where(u =>
            {
                if (!fd.timestamp.Equals(fd.testTimestamp))
                {
                    if (!fd.timestamp.Equals(u.Timestamp)) return false;
                }
                if (fd.flowId != null)
                {
                    if (!fd.flowId.Equals(u.FlowId.ToString())) return false;
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

        }
        void EventUC_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EventUC ev = (EventUC)e.Source;
            SuricataEvent s = (SuricataEvent)ev.DataContext;
            MessageBox.Show(s.SrcIp.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            customTimestamp.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            customSrcIp.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            customDestIp.Text = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            customProto.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            customAppProto.Text = "";
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            customFlowId.Text = "";
        }

        private void Button_ClearAllFilters(object sender, RoutedEventArgs e)
        {
            void clearFilters(StackPanel stackPanel)
            {
                var textBox = stackPanel.Children.OfType<TextBox>().ToList();
                foreach (var tb in textBox)
                    tb.Text = "";

                var checkBox = stackPanel.Children.OfType<CheckBox>().ToList();
                foreach (var cb in checkBox)
                    cb.IsChecked = false;
            }

            string stackPanelName = "stackPanel";
            for(int i = 1; i < 8; i++)
            {
                clearFilters((StackPanel)this.FindName(stackPanelName + i));
            }
        }
        private void fillEventListView(List<SuricataEvent> events)
        {
            eventListView.Items.Clear();
            if (events != null)
                foreach (var evt in events)
                {
                    EventUC eventUC = new EventUC(evt);
                    eventUC.MouseLeftButtonUp += new MouseButtonEventHandler(EventUC_MouseLeftButtonUp);
                    eventListView.Items.Add(eventUC);
                }
            mainExpander.IsExpanded = false;
            headerTextBlock.Text = "Events (Current count: " + events.Count + ")";
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
                if (!customFlowId.Text.Trim().Equals("")) flowId =  customFlowId.Text.Trim();
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
            FilterData filterData = new FilterData(timestamp, flowId, listEventType, srcIp, destIp, listProto, listAppProto);
            return filterData;
        }

        private class FilterData
        {
            public DateTime timestamp;
            public string flowId;
            public List<string> listEventType;
            public string SrcIp;
            public string DestIp;
            public List<string> listProto;
            public List<string> listAppProto;
            public DateTime testTimestamp = new DateTime();
            public FilterData(DateTime timestamp, string flowId, List<string> listEventType, string srcIp, string destIp, List<string> listProto, List<string> listAppProto)
            {
                this.timestamp = timestamp;
                this.flowId = flowId;
                this.listEventType = listEventType;
                SrcIp = srcIp;
                DestIp = destIp;
                this.listProto = listProto;
                this.listAppProto = listAppProto;
            }

            public bool checkForCoincidencetimestamp(SuricataEvent evnt)
            {
                if (!timestamp.Equals(testTimestamp))
                {

                }
                return true;
            }
        }
    }
}


