using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;

namespace ProduktDatabase;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FillDataGrid();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // ny produkt
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        // rediger produkt
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        // slet produkt
    }

    private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        // datagrid
    }
    
    private void FillDataGrid()
    {
        try
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "127.0.0.1";
            builder.InitialCatalog = "cbz";
            builder.UserID = "root";
            builder.Password = "";
            string connectionString = builder.ConnectionString;
            //string connectionString = "Server=localhost;Database=cbz;User Id=root;Password=;";
            string query = "SELECT * FROM YourTableName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                myDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}