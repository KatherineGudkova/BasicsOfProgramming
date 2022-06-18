using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter; 
        public Window2()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Products();
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
        private void Products()
        {
            string sqlQ = "SELECT Products.IDProducts as [Код продукції]," +
            "Products.NameProducts as [Назва]," +
            "TypeProducts.TypeProducts as [Вид продукції] "+
            "FROM dbo.Products INNER JOIN "+
            "TypeProducts ON TypeProducts.IDTypeProducts = Products.IDTypeProducts;";
            try
            {
                GetAndShowData(sqlQ, Tab2);
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
