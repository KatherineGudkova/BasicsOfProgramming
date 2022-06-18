using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;

        public Window4()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Request();
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
        private void Request()
        {
            string sqlQ =
            "SELECT Edition.NameEdition as [Місто розміщення],"+
   "Request.ReleasedateRequest as [Дата виходу]," +
   "Request.ContentRequest as [Зміст]," +
   "PriceList.ResultPrice as [Вартість]," +
   "Request.Payment as [Відмітка про оплату]," +
   "Products.NameProducts as [Рекламна продукція]," +
   "Advertisers.Surname AS [Прізвище рекламодавця],"+
   "Advertisers.Name AS [І'мя рекламодавця]" +
   " FROM Request INNER JOIN  " +
   "Edition ON Edition.IDEdition = Request.IDEdition INNER JOIN  " +
   "PriceList ON PriceList.IDServices = Request.IDService INNER JOIN  " +
   "Products ON Products.IDProducts = Request.IDProducts INNER JOIN  " +
   "Advertisers on Advertisers.IDAdvertisers = Request.IDAdvertisers " +
   "WHERE Request.Payment = 1 ORDER BY " +
   "Request.ReleasedateRequest;";

            try
            {
                GetAndShowData(sqlQ, Tab4);
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
