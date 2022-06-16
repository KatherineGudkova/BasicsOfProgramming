using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows;

namespace PR3
{
    /// <summary>
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class Entrance : Window
    {
        public Entrance()
        {
            InitializeComponent();
        }
        static SqlConnection conn;
        public static string LOGIN;
        int TryConnection = 3;
        public static void CreatePassword(string login, string pass)
        {
            var CommandUpdateLogin = new SqlCommand($"update DBInfo set Password = '{pass}' where Login = '{login}';", conn);
            CommandUpdateLogin.ExecuteNonQuery();

        }

        private bool CheckPassword(string pass)
        {
            if (Regex.Match(pass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9])\S{1,16}$").Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string sqlConnection = @"Server = DESKTOP-P75QV9I;" + "Database = Pr3;" + "Integrated Security = true";
                conn = new SqlConnection(sqlConnection);
                conn.Open();

                var GetData = new SqlDataAdapter($"select Login,Password,Access,PassLimit from DBInfo where Login='{Login.Text}'", conn);

                DataTable dt = new DataTable();
                GetData.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    LOGIN = Login.Text;
                    if (dt.Rows[0][1].ToString() == "")
                    {
                        if (Password.Password != "")
                        {
                            CreatePassword(Login.Text, Password.Password);
                            MessageBox.Show("Пароль оновлено!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Користувачів з таким логіном не існує!");
                    return;
                }
                conn.Close();


                if (Login.Text == "Admin")
                {
                    if (dt.Rows[0][1].ToString()==Password.Password)
                    {
                        Administration administration = new Administration();
                        administration.Show();
                        Hide();
                    }
                    else
                    {
                        TryConnection--;
                        MessageBox.Show($"Неправильний пароль. Залишилось спроб: {TryConnection}");
                        if (TryConnection == 0)
                            App.Current.Shutdown();
                    }
                }
                else
                {
                    if (dt.Rows[0][1].ToString()==Password.Password)
                    {
                        if ((bool)dt.Rows[0][2] == false)
                        {
                            MessageBox.Show("Ви заблоковані.");
                            return;
                        }

                        if ((bool)dt.Rows[0][3] == true)
                        {
                            if (!CheckPassword(Password.Password))
                            {
                                MessageBox.Show("Пароль не містить великої літери, цифри та нижнього підкреслення.");
                                return;
                            }
                        }

                        ChangePass up = new ChangePass();
                        up.Show();
                        Hide();
                    }
                    else
                    {
                        TryConnection--;
                        MessageBox.Show($"Неправильний пароль. Залишилось спроб: {TryConnection}");
                        if (TryConnection == 0)
                            App.Current.Shutdown();
                    }
                }
            }
            catch { MessageBox.Show("ПОМИЛКА", "Неправильний формат даних!"); }
        }

        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
