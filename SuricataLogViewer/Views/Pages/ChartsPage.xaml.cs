﻿using SuricataLogViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuricataLogViewer.Views.Pages
{
    /// <summary>
    /// Interaction logic for ChartsPage.xaml
    /// </summary>
    public partial class ChartsPage : Page
    {
        public ChartsPage()
        {
            InitializeComponent();
            Task.Run(() => IpService.GetIpInfo(SuricataService.GetLog()));
        }
    }
}