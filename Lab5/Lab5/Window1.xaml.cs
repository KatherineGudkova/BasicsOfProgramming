using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;

namespace Lab5
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
        DataTable Table = new DataTable();

        public Window1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Edition();
            CBoxItems.ItemsSource = GetItems();
            CBoxItems.SelectedIndex = 0;
        }

        private String[] GetItems()
        {
            String[] Items = { "" };

            connection = new SqlConnection(connectionString);
            connection.Open();

            if (connection.State==ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM TypeEdition",connection);
                Table = new DataTable("Edition");
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
            Table = new DataTable("Edition");
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;
            connection.Close();
        }
        private void Edition()
        {
            string sqlQ = "SELECT Edition.IDEdition as [№]," +
                "Edition.NameEdition as [Назва видання]," +
       "TypeEdition.TypeEdition as [Тип видання]" +
       "FROM Edition INNER JOIN  " +
       "TypeEdition ON TypeEdition.IDTypeEdition = Edition.IDTypeEdition ORDER BY " +
       "Edition.IDEdition;";
            try
            {
                GetAndShowData(sqlQ, Tab1);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
        

        private void AddTab1_Click(object sender, RoutedEventArgs e)
        {
            String IDEdition, NameEdition, IDTypeEdition = "";
            connection = new SqlConnection(connectionString);
            connection.Open ();

            if(connection.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("SELECT * FROM Edition", connection);
                Table = new DataTable("Edition");
                adapter.Fill(Table);

                if (Table.Rows.Count > 0)
                    IDEdition = (1 + Convert.ToInt32(Table.Rows[Table.Rows.Count - 1][0])).ToString();
                else
                    IDEdition = "1";
                NameEdition = Name.Text;

                for(int i = 0;i < Table.Rows.Count; i++)
                {
                    if (CBoxItems.SelectedIndex == i)
                        IDTypeEdition = (i + 1).ToString();
                }

                string sqlQ = "";
                sqlQ += "INSERT INTO Edition (IDEdition,NameEdition, IDTypeEdition)";
                sqlQ += "values ('" + IDEdition + "','" + NameEdition + "','" + IDTypeEdition + "');";
                command = new SqlCommand(sqlQ,connection);
                MessageBox.Show(command.ExecuteNonQuery().ToString());
                connection.Close();
                Edition();

            }
        }
        
        private void DeleteTab1_Click(object sender, RoutedEventArgs e)
        {
            connection = new SqlConnection (connectionString);
            connection.Open (); 
            if(connection.State == ConnectionState.Open)
            {
                try
                {
                   String ID;
                    adapter = new SqlDataAdapter("SELECT * FROM Edition", connection);
                    Table = new DataTable("Edition");
                    adapter.Fill (Table);

                    ID = IDEditionDel.Text;
                    string sqlQ = "DELETE FROM Edition WHERE IDEdition = '" + ID + "';";
                    command = new SqlCommand(sqlQ,connection);
                    MessageBox.Show(command.ExecuteNonQuery().ToString());
                    connection.Close();
                    Edition();
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
