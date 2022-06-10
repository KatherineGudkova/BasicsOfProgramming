using System.Windows;

namespace Lab2
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
            w1 = new Window1();
            Hide();
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2;
            w2 = new Window2();
            Hide();
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3;
            w3 = new Window3();
            Hide();
        }

        private void Inf_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4;
            w4 = new Window4();
            Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
