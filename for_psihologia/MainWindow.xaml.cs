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

namespace for_psihologia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSelectTests_Click(object sender, RoutedEventArgs e)
        {
            Window1Panel.Visibility = Visibility.Collapsed;
            Window2Panel.Visibility = Visibility.Visible;
        }

        private void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            Window1Panel.Visibility = Visibility.Visible;
            Window2Panel.Visibility = Visibility.Collapsed;
        }
    }
}
