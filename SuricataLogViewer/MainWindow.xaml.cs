using SuricataLogViewer.Models;
using SuricataLogViewer.Services;
using System.Windows;
using System.Windows.Controls;

namespace SuricataLogViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sideBar.Visibility == Visibility.Collapsed)
            {
                sideBar.Visibility = Visibility.Visible;
                sideBarRotateTransform.Angle = 90;
                SideBarElement.UseFullName = true;
            }
            else
            {
                sideBar.Visibility = Visibility.Collapsed;
                sideBarRotateTransform.Angle = 0;
                SideBarElement.UseFullName = false;
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = PageService.GetPageObject<Page>();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = PageService.GetPageObject<Page>();
        }
    }
}
