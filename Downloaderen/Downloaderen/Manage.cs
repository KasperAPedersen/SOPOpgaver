using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MySql.Data.MySqlClient;

namespace Downloaderen
{
    public partial class Manage : MetroForm
    {
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        private static readonly string connectionString = $"SERVER=localhost;DATABASE=downloaderen;UID=root;PWD=;Convert Zero Datetime=True;Pooling=True;";
        private int userId;

        public Manage(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add btn
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var row = dataGridView1.Rows[dataGridView1.Rows.Count - 2];

                string query = "INSERT INTO downloads (user_id, url) VALUES (@Value1, @Value2)";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Value1", userId);
                    command.Parameters.AddWithValue("@Value2", row.Cells["url"].Value ?? DBNull.Value);
                    command.ExecuteNonQuery(); // Execute insert command
                }
            }

            MessageBox.Show("Download added successfully");
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // del btn
            var id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM downloads WHERE ID = @ID";
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
                                LoadData();
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

        private void LoadData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    adapter = new MySqlDataAdapter($"SELECT id, url FROM downloads WHERE user_id = {userId}", connection);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
