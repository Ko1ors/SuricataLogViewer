using SuricataLogViewer.Models;
using SuricataLogViewer.Services;
using System.Windows;
using System.Windows.Controls;

namespace SuricataLogViewer
{
    /// <summary>
    /// Логика взаимодействия для ViewEl.xaml
    /// </summary>
    public partial class ViewEl : Window
    {
        ViewElement element = new ViewElement();

        public ViewEl()
        {
            InitializeComponent();
            CreateATextBlock();
        }
        private void ExitButton_Click1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CreateATextBlock()
        {
            TextBlock txtBlock = new TextBlock();
            txtBlock.Height = notes.Height;
            txtBlock.Width = notes.Width;
            txtBlock.FontSize = 14;
            txtBlock.Text = element.outputEl(0);
            notes.Children.Add(txtBlock);
        }
    }
}
