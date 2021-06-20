using LiveCharts;
using LiveCharts.Wpf;
using SuricataLogViewer.ViewModels;
using System.Windows.Controls;

namespace SuricataLogViewer.Views.UserControls
{
    /// <summary>
    /// Interaction logic for EventPieChartUC.xaml
    /// </summary>
    public partial class EventPieChartUC : UserControl
    {
        public EventPieChartUC()
        {
            InitializeComponent();

            DataContext = new PieChartViewModel(Models.PieChartType.Event);
        }
    }
}
