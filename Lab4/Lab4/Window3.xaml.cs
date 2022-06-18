using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public Window3()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Advertisers();
        }
        private void GetAndShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        private void Advertisers()
        {
            string sqlQ = "SELECT Advertisers.Surname as [Прізвище], " +
                "Advertisers.Name as [Ім'я], " +
                "Advertisers.Secname as [По батькові]," + "Advertisers.Address as [Адреса]," +
                "Advertisers.PhoneNumber AS [Номер телефону]" +
                "FROM Advertisers ORDER BY " +
                "Advertisers.Surname, Advertisers.Name, Advertisers.Secname;";
            try
            {
                GetAndShowData(sqlQ, Tab3);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
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
