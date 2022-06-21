using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab5
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
        DataTable Table = new DataTable();

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
            Table = new DataTable("Advertisers");
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        private void Advertisers()
        {
            string sqlQ = "SELECT Advertisers.IDAdvertisers as [№]," +
                "Advertisers.Surname as [Прізвище], " +
                "Advertisers.Name as [Ім'я], " +
                "Advertisers.Secname as [По батькові]," + "Advertisers.Address as [Адреса]," +
                "Advertisers.PhoneNumber AS [Номер телефону]" +
                "FROM Advertisers ORDER BY " +
                "Advertisers.IDAdvertisers;";
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

        private void AddTab3_Click(object sender, RoutedEventArgs e)
        {
            String IDAdvertisers, Surname, Name, Secname, Address, PhoneNumber;
            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Advertisers", connection);
                Table = new DataTable("Advertisers");
                adapter.Fill(Table);

                if (Table.Rows.Count > 0)
                    IDAdvertisers = (1 + Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0])).ToString();
                else
                    IDAdvertisers = "1";

                Surname = SurnameAd.Text;
                Name = NameAd.Text;
                Secname = SecnameAd.Text; 
                Address = AddressAd.Text;
                PhoneNumber = PhoneNumberAd.Text;

                string sqlQ = "";
                sqlQ += "INSERT INTO Advertisers (IDAdvertisers,Surname, Name, Secname, Address, PhoneNumber)";
                sqlQ += "values ('" + IDAdvertisers + "','" + Surname + "','"  + Name + "','" + Secname + "','" + Address + "','" + PhoneNumber + "');";
                command = new SqlCommand(sqlQ, connection);

                MessageBox.Show(command.ExecuteNonQuery().ToString());
                connection.Close();
                Advertisers();
            }
        }

        private void DeleteTab3_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                try
                {
                    String ID;
                    adapter = new SqlDataAdapter("SELECT * FROM Advertisers", connection);
                    Table = new DataTable("Advertisers");
                    adapter.Fill(Table);

                    ID = IDAdvertisersDel.Text;
                    string sqlQ = "DELETE FROM Advertisers WHERE IDAdvertisers = '" + ID + "';";
                    command = new SqlCommand(sqlQ, connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    connection.Close();
                    Advertisers();
                }
                catch { }
            }
        }
    }
}
