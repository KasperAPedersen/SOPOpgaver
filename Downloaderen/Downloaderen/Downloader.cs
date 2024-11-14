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
using System.Diagnostics;
using System.Net;
using MySql.Data.MySqlClient;

namespace Downloaderen
{
    public partial class Downloader : MetroForm
    {
        private int userId;
        private static readonly string connectionString = $"SERVER=localhost;DATABASE=downloaderen;UID=root;PWD=;Convert Zero Datetime=True;Pooling=True;";
        
        public Downloader(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.FormClosed += Downloader_FormClosed;
        }

        private void Downloader_Load(object sender, EventArgs e)
        {

        }
        
        private void Downloader_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            string query = $"SELECT url FROM downloads WHERE user_id = {userId}";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    DownloadFile(item.ToString());
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Manage(userId).Show();
        }

        private void DownloadFile(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string fileName = Path.GetFileName(url);
                    string downloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName); // Specify your directory here
                    client.DownloadFile(url, downloadPath);
                    ExecuteInstaller($"{downloadPath}");

                    MessageBox.Show($"Downloaded {fileName} successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading file: {ex.Message}");
            }
        }


        private void ExecuteInstaller(string filePath)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = filePath;
                process.StartInfo.Arguments = ""; // Add any necessary arguments
                process.StartInfo.Verb = "runas"; // Run as administrator
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing installer: {ex.Message}");
            }
        }
    }
}
