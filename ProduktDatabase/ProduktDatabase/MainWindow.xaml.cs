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
}