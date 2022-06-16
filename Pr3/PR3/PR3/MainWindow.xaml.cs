using System.Windows;

namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static string sqlConnection = @"Server = DESKTOP-P75QV9I;" + "Database = Pr3;" + "Integrated Security = true";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            Entrance ent = new Entrance();
            ent.Show();
            Hide();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Hide();
        }

        private void AbouteDeveloper_Click(object sender, RoutedEventArgs e)
        {
            Developer dv = new Developer();
            dv.Show();
            Hide();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}