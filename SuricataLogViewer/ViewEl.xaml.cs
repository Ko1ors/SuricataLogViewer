using SuricataLogViewer.Models;
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
using System.Windows.Shapes;

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
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
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
