using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2
{
    class Window2
    {
        public Window2()
        {
            InitCal();
        }

        Window WN;
        Grid LayoutRoot;
        private void InitCal()
        {
            WN = IntCreate.WNCreate(600, 700, "Window2");
            LayoutRoot = IntCreate.GridCreate(600, 700);

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    IntCreate.CreateBox(50+(95 + 5) * i,50+(95+5)*j, LayoutRoot);


            Button ToMainWindow = IntCreate.ButtonCreate(65, 500, 600, 50, 20, "ГОЛОВНА СТОРІНКА", Brushes.White, LayoutRoot);
            
            ToMainWindow.Click += ToMainWindow_Click;

            WN.Content = LayoutRoot;
            WN.Show();
        }
        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            WN.Hide();
            MainWindow MW = new MainWindow();
            MW.Show();
        }
        
    }
}
