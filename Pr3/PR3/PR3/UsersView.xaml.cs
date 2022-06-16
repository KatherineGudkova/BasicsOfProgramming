using System.Data;
using System.Data.SqlClient;
using System.Windows;
namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для UsersView.xaml
    /// </summary>
    public partial class UsersView : Window
    {
        public UsersView()
        {
            InitializeComponent();
            UpdateDataTable();
            index = 0;
            ShowUser();
        }

        int index, LenTable;
        DataTable dT;
        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                ShowUser();
            }
        }
        private void ShowUser()
        {
            if (dT.Rows[index][0].ToString() != "")
                UserNameSelected.Content = "ІМ'Я: " + dT.Rows[index][0].ToString();
            else
                UserNameSelected.Content = "ІМ'Я ВІДСУТНЄ";

            if (dT.Rows[index][0].ToString() != "")
                UserSurnameSelected.Content = "ПРІЗВИЩЕ: " + dT.Rows[index][1].ToString();
            else
                UserSurnameSelected.Content = "ПРІЗВИЩЕ ВІДСУТНЄ";

            if (dT.Rows[index][0].ToString() != "")
                UserSecnameSelected.Content = "ПО БАТЬКОВІ: " + dT.Rows[index][2].ToString();
            else
                UserSecnameSelected.Content = "ПО БАТЬКОВІ ВІДСУТНЄ";
            UserLoginSelected.Content = dT.Rows[index][3].ToString();
            if ((bool)dT.Rows[index][4] == true)
                UserStatusSelected.IsChecked = true;
            else
                UserStatusSelected.IsChecked = false;
            if ((bool)dT.Rows[index][5] == true)
                UserRestrictionSelected.IsChecked = true;
            else
                UserRestrictionSelected.IsChecked = false;
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < LenTable - 1)
            {
                index++;
                ShowUser();
            }
        }
        SqlConnection conn;
        void UpdateDataTable()
        {
            string sqlConnection = @"Server = DESKTOP-P75QV9I;" + "Database = Pr3;" + "Integrated Security = true";

            conn = new SqlConnection(sqlConnection);
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                var Data = new SqlDataAdapter("SELECT Name, SurName,SecName, Login, Access,PassLimit  FROM DBInfo", conn);

                dT = new DataTable("Користувачі");
                Data.Fill(dT);
                dataGrid.ItemsSource = dT.DefaultView;
                LenTable = dT.Rows.Count;
            }

            conn.Close();
        }

        private void UserStatusSelected_Checked(object sender, RoutedEventArgs e)
        {
            conn.Open();
            var CommandUpdateStatus = new SqlCommand($"update DBInfo set Access = '" +
                       $"{UserStatusSelected.IsChecked}' where Login = '{UserLoginSelected.Content}';", conn);
            CommandUpdateStatus.ExecuteNonQuery();
            conn.Close();
            UpdateDataTable();
        }

        private void UserRestrictionSelected_Checked(object sender, RoutedEventArgs e)
        {
            conn.Open();
            var CommandUpdateStatus = new SqlCommand($"update DBInfo set PassLimit = '" +
                       $"{UserRestrictionSelected.IsChecked}' where Login = '{UserLoginSelected.Content}';", conn);
            CommandUpdateStatus.ExecuteNonQuery();
            conn.Close();
            UpdateDataTable();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Administration mainWindow = new Administration();
            mainWindow.Show();
            Hide();
        }

    }
}
