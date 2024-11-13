using System.Data;

namespace WinFormsApp1;

using MySql.Data.MySqlClient;
using System.Data.Common;

public partial class Form1 : Form
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
        Ny ny = new Ny();
        ny.Show();
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
}