using SuricataLogViewer.Model;
using SuricataLogViewer.Models;
using SuricataLogViewer.Services;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Navigation;

namespace SuricataLogViewer
{
    /// <summary>
    /// Логика взаимодействия для ViewEl.xaml
    /// </summary>
    public partial class ViewEl : Window
    {
        ViewElement element = new ViewElement();

        public ViewEl(SuricataEvent suricataEvent)
        {
            InitializeComponent();
            CreateATextBlock(suricataEvent);
        }
        private void ExitButton_Click1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Hyperlink_RequestNavigate(object sender, RoutedEventArgs e)
        {

            Process.Start("explorer.exe", "https://suricata.readthedocs.io/en/latest/output/index.html"); //открытие ссылки в браузере


        }

        private void CreateATextBlock(SuricataEvent suricataEvent)
        {
            TextBlock txtBlock = new TextBlock();
            TextBlock txtBlock2 = new TextBlock();
            txtBlock.Height = notes.Height;
            txtBlock.Width = notes.Width;
            txtBlock2.Height = notes.Height;
            txtBlock2.Width = notes.Width;
            txtBlock.FontSize = txtBlock2.FontSize = 14;

            txtBlock.Padding = new Thickness(10, 0, 0, 0);
            txtBlock2.Padding = new Thickness(190, 0, 0, 0);
            txtBlock.Foreground = Brushes.White;
            txtBlock2.Foreground = Brushes.Yellow;
            txtBlock.FontWeight = FontWeights.Bold;
            txtBlock2.FontWeight = FontWeights.Bold;
            txtBlock.Text = element.outputEl1(suricataEvent);
            txtBlock2.Text = element.outputEl2(suricataEvent);
            notes.Children.Add(txtBlock);
            notes.Children.Add(txtBlock2);
        }
    }
}
