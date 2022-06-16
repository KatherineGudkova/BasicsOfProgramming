using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        string sqlConnection = @"Server = DESKTOP-P75QV9I;" + "Database = Pr3;" + "Integrated Security = true";

        public ChangePass()
        {
            InitializeComponent();
            User.Content = $"User {Entrance.LOGIN}";

            conn = new SqlConnection(sqlConnection);
            conn.Open();

            var GetData = new SqlDataAdapter($"select SurName,Name,SecName from DBInfo where Login='{log}'", conn);
            DataTable dt = new DataTable();
            GetData.Fill(dt);

            SurName.Text = dt.Rows[0][0].ToString();
            Name.Text = dt.Rows[0][1].ToString();
            SecName.Text = dt.Rows[0][2].ToString();

            conn.Close();
        }
        SqlConnection conn;

        string log = Entrance.LOGIN;
       
        private void OK_Click_1(object sender, RoutedEventArgs e)
        {
conn = new SqlConnection(sqlConnection);

            conn.Open();

            var GetData = new SqlDataAdapter($"select Login,Password from DBInfo where Login='{log}'", conn);
            DataTable dt = new DataTable();
            GetData.Fill(dt);

            if (dt.Rows[0][1].ToString() == OldPass.Password)
            {
                if (NewPass.Password != "")
                {
                    var CommandUpdateLogin = new SqlCommand($"update DBInfo set Password = '" +
                        $"{NewPass.Password}' where Login = '{log}';", conn);
                    CommandUpdateLogin.ExecuteNonQuery();

                    MessageBox.Show("Пароль змінено успішно!");
                }
                else
                    MessageBox.Show("Новий пароль є пустою строкою!");
            }
            else
                MessageBox.Show("Введено невірний пароль!");


            if (SurName.Text != "")
            {
                var CommandUpdateLogin = new SqlCommand($"update DBInfo set Surname = '" +
                        $"{SurName.Text}' where Login = '{log}';", conn);
                CommandUpdateLogin.ExecuteNonQuery();
            }
            if (Name.Text != "")
            {
                var CommandUpdateLogin = new SqlCommand($"update DBInfo set Name = '" +
                        $"{Name.Text}' where Login = '{log}';", conn);
                CommandUpdateLogin.ExecuteNonQuery();
            }
            if (SecName.Text != "")
            {
                var CommandUpdateLogin = new SqlCommand($"update DBInfo set SecName = '" +
                        $"{SecName.Text}' where Login = '{log}';", conn);
                CommandUpdateLogin.ExecuteNonQuery();
            }

            conn.Close();
        }

        private void Back_Click_1(object sender, RoutedEventArgs e)
        {
            if (Entrance.LOGIN == "Admin")
            {
                Administration mw = new Administration();
                mw.Show();
            }
            else
            {
                MainWindow mw = new MainWindow();
                mw.Show();
            }
            Hide();
        }
    }
}
