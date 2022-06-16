using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Password.Password == "")
                MessageBox.Show("Заповніть поля ЛОГІН ТА ПАРОЛЬ!");
            else
            {
                var conn = new SqlConnection(MainWindow.sqlConnection);
                conn.Open();

                var CheckSameLogin = new SqlDataAdapter($"select count (*) from DBInfo where Login ='{Login.Text}'", conn);
                DataTable dt = new DataTable();
                CheckSameLogin.Fill(dt);

                if ((int)dt.Rows[0][0] == 0)
                {
                    var CommandUpdateLogin = new SqlCommand($"insert into DBInfo (Login,Password,Access,PassLimit) values ('{Login.Text}','{Password.Password}','true','false');", conn);
                    CommandUpdateLogin.ExecuteNonQuery();

                    if (SurName.Text != "")
                    {
                        var SurNameUpdate = new SqlCommand($"update DBInfo set SurName = '" + $"{SurName.Text}' where Login = '{Login.Text}';", conn);
                        SurNameUpdate.ExecuteNonQuery();
                    }

                    if (Name.Text != "")
                    {
                        var NameUpdate = new SqlCommand($"update DBInfo set Name = '" + $"{Name.Text}' where Login = '{Login.Text}';", conn);
                        NameUpdate.ExecuteNonQuery();
                    }
                    if (Name.Text != "")
                    {
                        var SecNameUpdate = new SqlCommand($"update DBInfo set SecName = '" + $"{SecName.Text}' where Login = '{Login.Text}';", conn);
                        SecNameUpdate.ExecuteNonQuery();
                    }
                    MessageBox.Show("Реєстрація пройшла успішно!");
                }
                else MessageBox.Show("Користувач з таким логіном вже існує!");

                conn.Close();
            }

        }


        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            Hide();
        }
    }
}
