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

namespace Lab4
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

        private void Tab1_Click(object sender, RoutedEventArgs e)
        {
            Window1 W1 = new Window1();
            W1.Show();
            Hide();
        }

        private void Tab2_Click(object sender, RoutedEventArgs e)
        {
            Window2 W2 = new Window2();
            W2.Show();
            Hide();
        }

        private void Tab3_Click(object sender, RoutedEventArgs e)
        {
            Window3 W3 = new Window3();
            W3.Show();
            Hide();
        }

        private void Tab4_Click(object sender, RoutedEventArgs e)
        {
            Window4 W4 = new Window4();
            W4.Show();
            Hide();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
