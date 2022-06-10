using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab2
{
    class Window4
    {
        public Window4()
        {
            InitMe();
        }

        Window WN;
        Grid LayoutRoot;
        private void InitMe()
        {
            WN = IntCreate.WNCreate(800, 450, "Window4");
            LayoutRoot = IntCreate.GridCreate(800, 450);

            TextBlock MyTitle = IntCreate.CreateTBlock(WN.Width, 100, 0, 50, 40, FontWeights.Bold, "ІНФОРМАЦІЯ ПРО РОЗРОБНИКА", LayoutRoot);
            MyTitle.TextAlignment = TextAlignment.Center;

            TextBlock MyText = IntCreate.CreateTBlock(640, 260, 30, 150, 36, FontWeights.Normal,
                "ПІБ: Гудкова Катерина Олексiївна \nГрупа: КП-13 \nРік створення програми: 2022",
                LayoutRoot);
            Button ToMainWindow = IntCreate.ButtonCreate(55, 295, 340, 30, 20, "ГОЛОВНА СТОРІНКА",  Brushes.White, LayoutRoot);
            Button Exit = IntCreate.ButtonCreate(55, 295, 340, 475, 20,"ВИХІД З ПРОГРАМИ", new SolidColorBrush(Color.FromRgb(232, 179, 179)), LayoutRoot);

            Exit.Click += Exit_Click;
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}