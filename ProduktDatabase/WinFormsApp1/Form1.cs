using System.Data;

namespace WinFormsApp1;

using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Transactions;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

public partial class Form1 : MetroForm
{
    private MySqlDataAdapter adapter;
    private DataTable dataTable;
    private static readonly string Conn = $"SERVER=localhost;DATABASE=cbz;UID=root;PWD=;Convert Zero Datetime=True;Pooling=True;";

    public Form1()
    {
        InitializeComponent();
        LoadDataFromDatabase();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {


    }

    internal void LoadDataFromDatabase()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Conn))
            {
                connection.Open();
                adapter = new MySqlDataAdapter("SELECT * FROM tablename", connection);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading data: " + ex.Message);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // add
        using (MySqlConnection conn = new MySqlConnection(Conn))
        {
            conn.Open();
            var row = dataGridView1.Rows[dataGridView1.Rows.Count - 2];

            string query = "INSERT INTO tablename (Producent_navn, Producent_adresse, Vare_nummer, Vare_tekst, Kategori, Materiale, Lager_beholdning) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7)";

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Value1", row.Cells["Producent_navn"].Value ?? DBNull.Value);
                command.Parameters.AddWithValue("@Value2", row.Cells["Producent_adresse"].Value ?? DBNull.Value);
                command.Parameters.AddWithValue("@Value3", row.Cells["Vare_nummer"].Value ?? DBNull.Value);
                command.Parameters.AddWithValue("@Value4", row.Cells["Vare_tekst"].Value ?? DBNull.Value);
                command.Parameters.AddWithValue("@Value5", row.Cells["Kategori"].Value ?? DBNull.Value);
                command.Parameters.AddWithValue("@Value6", row.Cells["Materiale"].Value ?? DBNull.Value);
                command.Parameters.AddWithValue("@Value7", row.Cells["Lager_beholdning"].Value ?? DBNull.Value);
                command.ExecuteNonQuery(); // Execute insert command
            }
        }

        MessageBox.Show("Row added su");
        LoadDataFromDatabase();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        // delete
        var currentRow = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
        DeleteRow(currentRow);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        // update
        UpdateDatabase();
    }

    private void UpdateDatabase()
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Conn))
            {
                connection.Open();
                adapter.SelectCommand.Connection = connection;
                MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                // End any current edit
                dataGridView1.EndEdit();

                // Update the database
                int rowsAffected = adapter.Update(dataTable);

                MessageBox.Show($"Database updated successfully! Rows affected: {rowsAffected}");

                // Refresh the data
                LoadDataFromDatabase();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error updating database: " + ex.Message);
        }
    }

    private void DeleteRow(int id)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Conn))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM tablename WHERE ID = @ID";
                using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    // Confirm deletion with the user
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully!");
                            // Refresh the DataGridView
                            LoadDataFromDatabase();
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. Record not found.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error deleting record: " + ex.Message);
        }
    }

    private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
    {


    }

    private void AddNewRowToDatabase(DataGridViewRow row)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(Conn))
            {
                connection.Open();
                string insertQuery = "INSERT INTO tablename (Producent_navn, Producent_adresse, Vare_nummer, Vare_tekst, Kategori, Materiale, Lager_beholdning) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7)";
                using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                {
                    // Add parameters for each column in your table
                    command.Parameters.AddWithValue("@Value1", row.Cells["Producent_navn"].Value ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Value2", row.Cells["Producent_adresse"].Value ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Value3", row.Cells["Vare_nummer"].Value ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Value4", row.Cells["Vare_tekst"].Value ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Value5", row.Cells["Kategori"].Value ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Value6", row.Cells["Materiale"].Value ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Value7", row.Cells["Lager_beholdning"].Value ?? DBNull.Value);
                    // Add more parameters as needed for additional columns

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Row added successfully to the database!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add row to the database.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding row to database: " + ex.Message);
        }
    }

    private void metroButton1_Click(object sender, EventArgs e)
    {
        ExcelToSQL excelToSQL = new ExcelToSQL();
        excelToSQL.Show();
    }
}