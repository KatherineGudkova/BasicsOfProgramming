using System.Data;
using System.Data.SqlClient;
using System.Windows;
namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != "")
            {
                SqlConnection conn;

                conn = new SqlConnection(MainWindow.sqlConnection);
                conn.Open();

                var CheckSameLogin = new SqlDataAdapter($"select count (*) from DBInfo where Login ='{Login.Text}'", conn);
                DataTable dt = new DataTable();
                CheckSameLogin.Fill(dt);

                if ((int)dt.Rows[0][0] == 0)
                {

                    var LoginCommand = new SqlCommand($"insert into DBInfo (Login,Access,PassLimit) values('{Login.Text}','1','0');", conn);
                    LoginCommand.ExecuteNonQuery();

                    MessageBox.Show("Реєстрація пройшла успішно!");
                }
                else MessageBox.Show("Користувач з таким логіном вже існує!");

                conn.Close();
            }
            else MessageBox.Show("Заповніть поле ЛОГІН!");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Administration ad = new Administration();
            ad.Show();
            Hide();
        }
    }
}
