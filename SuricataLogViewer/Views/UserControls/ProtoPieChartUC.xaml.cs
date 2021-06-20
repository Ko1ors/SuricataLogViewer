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
    /// Interaction logic for ProtoPieChartUC.xaml
    /// </summary>
    public partial class ProtoPieChartUC : UserControl
    {
        public ProtoPieChartUC()
        {
            InitializeComponent();

            DataContext = new PieChartViewModel(Models.PieChartType.Protocol);
        }
    }
}
