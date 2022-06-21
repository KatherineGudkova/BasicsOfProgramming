using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab5
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
            DataTable Table = new DataTable();
        public Window2()
            {
                InitializeComponent();
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                Products();
                CBoxItems.ItemsSource = GetItems();
                CBoxItems.SelectedIndex = 0;
            }

        private String[] GetItems()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM TypeProducts", connection);
                Table = new DataTable("Products");
                adapter.Fill(Table);

                Items = new String[Table.Rows.Count];
                for (int i = 0; i < Table.Rows.Count; i++)
                    Items[i] = Table.Rows[i][0].ToString() + ". " + Table.Rows[i][1].ToString();
            }
            return Items;
        }
            private void GetAndShowData(string SQLQuery, DataGrid dataGrid)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command = new SqlCommand(SQLQuery, connection);
                adapter = new SqlDataAdapter(command);
                Table = new DataTable("Products");
                adapter.Fill(Table);
                dataGrid.ItemsSource = Table.DefaultView;
                connection.Close();
            }
            private void Products()
            {
                string sqlQ = "SELECT Products.IDProducts as [Код продукції]," +
                "Products.NameProducts as [Назва]," +
                "TypeProducts.TypeProducts as [Вид продукції] " +
                "FROM dbo.Products INNER JOIN " +
                "TypeProducts ON TypeProducts.IDTypeProducts = Products.IDTypeProducts;";
                try
                {
                    GetAndShowData(sqlQ, Tab2);
                }
                catch (Exception e)
                { Console.WriteLine(e.Message); }
            }

            
        private void AddTab2_Click(object sender, RoutedEventArgs e)
        {
            String IDProducts, NameProducts, IDTypeProducts="";

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
                Table = new DataTable("Products");
                adapter.Fill(Table);

                if (Table.Rows.Count > 0)
                    IDProducts = (1 + Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0])).ToString();
                else
                    IDProducts = "1";
                NameProducts = Name.Text;

                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    if (CBoxItems.SelectedIndex == i)
                        IDTypeProducts = (i + 1).ToString();
                }

                string sqlQ = "";
                sqlQ += "INSERT INTO Products (IDProducts,NameProducts, IDTypeProducts)";
                sqlQ += "values ('" + IDProducts + "','" + NameProducts + "','" + IDTypeProducts + "');";
                command = new SqlCommand(sqlQ, connection);

                MessageBox.Show(command.ExecuteNonQuery().ToString());
                connection.Close();
                Products();
            }
        }

        private void DeleteTab2_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    String ID;
                    adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
                    Table = new DataTable("Edition");
                    adapter.Fill(Table);

                    ID = IDProductsDel.Text;
                    string sqlQ = "DELETE FROM Products WHERE IDProducts = '" + ID + "';";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    connection.Close();
                    Products();
                }
                catch { }
            }
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
