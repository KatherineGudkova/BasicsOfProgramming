using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для Developer.xaml
    /// </summary>
    public partial class Developer : Window
    {
        public Developer()
        {
            InitializeComponent();
        }

        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
