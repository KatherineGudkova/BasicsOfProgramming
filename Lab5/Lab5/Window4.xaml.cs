using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab5
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
        DataTable Table = new DataTable();
        public Window4()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Request();
            PriceList();

            CBoxFormat.ItemsSource = GetFormat();
            CBoxFormat.SelectedIndex = 0;

            CBoxTypeEdition.ItemsSource = GetTypeEdition();
            CBoxTypeEdition.SelectedIndex = 0;

            CBoxEdition.ItemsSource = GetEdition();
            CBoxEdition.SelectedIndex = 0;

            CBoxProducts.ItemsSource = GetProducts();
            CBoxProducts.SelectedIndex = 0;

            CBoxAdvertisers.ItemsSource = GetAdvertisers();
            CBoxAdvertisers.SelectedIndex = 0;
        }

        private String[] GetTypeEdition()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM TypeEdition", connection);
                Table = new DataTable("PriceList");
                adapter.Fill(Table);

                Items = new String[Table.Rows.Count];
                for (int i = 0; i < Table.Rows.Count; i++)
                    Items[i] = Table.Rows[i][0].ToString() + ". " + Table.Rows[i][1].ToString();
            }
            return Items;
        }
        private String[] GetFormat()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM FormatProd", connection);
                Table = new DataTable("PriceList");
                adapter.Fill(Table);

                Items = new String[Table.Rows.Count];
                for (int i = 0; i < Table.Rows.Count; i++)
                    Items[i] = Table.Rows[i][0].ToString() + ". " + Table.Rows[i][1].ToString();
            }
            return Items;
        }

        private String[] GetEdition()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Edition", connection);
                Table = new DataTable("Edition");
                adapter.Fill(Table);

                Items = new String[Table.Rows.Count];
                for (int i = 0; i < Table.Rows.Count; i++)
                    Items[i] = Table.Rows[i][0].ToString() + ". " + Table.Rows[i][1].ToString();
            }
            return Items;
        }
        private String[] GetProducts()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
                Table = new DataTable("Products");
                adapter.Fill(Table);

                Items = new String[Table.Rows.Count];
                for (int i = 0; i < Table.Rows.Count; i++)
                    Items[i] = Table.Rows[i][0].ToString() + ". " + Table.Rows[i][1].ToString();
            }
            return Items;
        }
        private String[] GetAdvertisers()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Advertisers", connection);
                Table = new DataTable("Advertisers");
                adapter.Fill(Table);

                Items = new String[Table.Rows.Count];
                for (int i = 0; i < Table.Rows.Count; i++)
                    Items[i] = Table.Rows[i][0].ToString() + ". " + Table.Rows[i][1].ToString() + " " + Table.Rows[i][2].ToString();
            }
            return Items;
        }
        private void GetAndShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        private void Request()
        {
            string sqlQ =
            "SELECT Request.IDRequest as [№]," +
            "Edition.NameEdition as [Місто розміщення]," +
            "Request.ReleasedateRequest as [Дата виходу]," +
            "Request.ContentRequest as [Зміст]," +
            "PriceList.ResultPrice as [Вартість]," +
            "Request.Payment as [Відмітка про оплату]," +
            "Products.NameProducts as [Рекламна продукція]," +
            "Advertisers.Surname AS [Прізвище рекламодавця]," +
            "Advertisers.Name AS [І'мя рекламодавця]" +
            " FROM Request INNER JOIN  " +
            "Edition ON Edition.IDEdition = Request.IDEdition INNER JOIN  " +
            "PriceList ON PriceList.IDServices = Request.IDService INNER JOIN  " +
            "Products ON Products.IDProducts = Request.IDProducts INNER JOIN  " +
            "Advertisers on Advertisers.IDAdvertisers = Request.IDAdvertisers;";

            try
            {
                GetAndShowData(sqlQ, Tab4);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        private void PriceList()
        {
            String IDCBoxFormat = "", IDCBoxTypeEdition = "";


            for (int i = 0; i < 22; i++)
            {
                if (CBoxFormat.SelectedIndex == i)
                    IDCBoxFormat = (i + 1).ToString();
            }

            for (int i = 0; i < 18; i++)
            {
                if (CBoxTypeEdition.SelectedIndex == i)
                    IDCBoxTypeEdition = (i + 1).ToString();
            }

            string sqlQ = "SELECT PriceList.IDServices as [№]," +
                "FormatProd.FormatName as [Формат]," +
                "TypeEdition.TypeEdition as [Тип видання]," +
                "PriceList.ResultPrice AS [Вартість] FROM " +
                "PriceList INNER JOIN FormatProd ON FormatProd.IDFormat = PriceList.IDFormat INNER JOIN " +
                "TypeEdition ON TypeEdition.IDTypeEdition = PriceList.IDTypeEdition";

            try
            {
                GetAndShowData(sqlQ, PriceListTab);
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

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
          String IDCBoxFormat = "", IDCBoxTypeEdition = "";
                  
          for (int i = 0; i < 22; i++)
          {
              if (CBoxFormat.SelectedIndex == i)
                 IDCBoxFormat = (i + 1).ToString();
          }

          for (int i = 0; i < 18; i++)
          {
              if (CBoxTypeEdition.SelectedIndex == i)
              IDCBoxTypeEdition = (i + 1).ToString();
          }
           
          string sqlQ = "SELECT PriceList.IDServices as [№]," +
                "FormatProd.FormatName as [Формат]," +
                "TypeEdition.TypeEdition as [Тип видання]," +
                "PriceList.ResultPrice AS [Вартість] FROM " +
                "PriceList INNER JOIN FormatProd ON FormatProd.IDFormat = PriceList.IDFormat INNER JOIN " +
                "TypeEdition ON TypeEdition.IDTypeEdition = PriceList.IDTypeEdition" +
                $" WHERE FormatProd.IDFormat = '{IDCBoxFormat}' AND TypeEdition.IDTypeEdition = '{IDCBoxTypeEdition}';";
            try
            {
                GetAndShowData(sqlQ, PriceListTab);
            }
            catch (Exception a)
            { Console.WriteLine(a.Message); }
        }

        private void AddTab4_Click(object sender, RoutedEventArgs e)
        {
            String IDRequest, IDEdition = "", ReleasedateRequest, ContentRequest, IDService, IDProducts = "", IDAdvertisers = "", Payment;
            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Request", connection);
                Table = new DataTable("Request");
                adapter.Fill(Table);

                if (Table.Rows.Count > 0)
                    IDRequest = (1 + Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0])).ToString();
                else
                    IDRequest = "1";

                for (int i = 0; i < 22; i++)
                {
                    if (CBoxEdition.SelectedIndex == i)
                        IDEdition = (i + 1).ToString();
                }
                ReleasedateRequest = DataTime.Text;
                ContentRequest = Cont.Text;
                IDService = Price.Text;

                for (int i = 0; i < 22; i++)
                {
                    if (CBoxProducts.SelectedIndex == i)
                        IDProducts = (i + 1).ToString();
                }
                for (int i = 0; i < 22; i++)
                {
                    if (CBoxAdvertisers.SelectedIndex == i)
                        IDAdvertisers = (i + 1).ToString();
                }
                Payment = PaymentTab.IsChecked.ToString();

                string sqlQ = "";
                sqlQ += "INSERT INTO Request (IDRequest,ContentRequest,ReleasedateRequest,IDAdvertisers,IDProducts,IDEdition,IDService,Payment)";
                sqlQ += "values ('" + IDRequest + "','" + ContentRequest + "','" + ReleasedateRequest + "','" + IDAdvertisers + "','" + IDProducts + "','" + IDEdition + "','" + IDService + "','" + Payment + "');";
                command = new SqlCommand(sqlQ, connection);

                MessageBox.Show(command.ExecuteNonQuery().ToString());
                connection.Close();
                Request();
            }
        }

        private void DeleteTab4_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    String ID;
                    adapter = new SqlDataAdapter("SELECT * FROM Request", connection);
                    Table = new DataTable("Request");
                    adapter.Fill(Table);

                    ID = IDRequestDel.Text;
                    string sqlQ = "DELETE FROM Request WHERE IDRequest = '" + ID + "';";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    connection.Close();
                    Request();
                }
                catch { }
            }
        }
    }
}
