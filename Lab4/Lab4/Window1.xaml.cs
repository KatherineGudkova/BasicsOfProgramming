using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public Window1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Edition();
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
        private void Edition()
        {
            string sqlQ = "SELECT Edition.NameEdition as [Назва видання]," +
       "TypeEdition.TypeEdition as [Тип видання]" +
       "FROM Edition INNER JOIN  " +
       "TypeEdition ON TypeEdition.IDTypeEdition = Edition.IDTypeEdition ORDER BY " +
       "Edition.NameEdition;"; 
            try
            {
                GetAndShowData(sqlQ,Tab1);
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
