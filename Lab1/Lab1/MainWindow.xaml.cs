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

namespace Lab1
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

        private void DataBase_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1;
            w1= new Window1();
            Hide();
            w1.Show();
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2;
            w2 = new Window2();
            Hide();
            w2.Show();
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3;
            w3 = new Window3();
            Hide();
            w3.Show();
        }

        private void Inf_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4;
            w4 = new Window4();
            Hide();
            w4.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
