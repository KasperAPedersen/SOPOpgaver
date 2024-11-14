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

namespace Downloaderen
{
    public partial class Manage : MetroForm
    {
        static string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string pathToLinks = $"{projectDirectory}\\links.txt";
        
        public Manage()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckFile();
            
            var row = dataGridView1.Rows[dataGridView1.Rows.Count - 2];
            var url = row.Cells[0].Value.ToString();
            File.AppendAllText(pathToLinks, $"{url}\n");
            LoadData();
            MessageBox.Show("Record added successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFile();
                
                var url = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var lines = File.ReadAllLines(pathToLinks).ToList();
                var index = lines.FindIndex(x => x == url);
                lines.RemoveAt(index);
                File.WriteAllLines(pathToLinks, lines);
                LoadData();
                MessageBox.Show("Record deleted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message);
            }
        }

        private void LoadData()
        {
            CheckFile();
            
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            
            dataGridView1.Columns.Add("Column1", "URL");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var lines = File.ReadAllLines(pathToLinks);
            
            lines.ToList().ForEach(x => dataGridView1.Rows.Add(x));
        }

        private void CheckFile()
        {
            if (!File.Exists(pathToLinks))
            {
                File.Create(pathToLinks).Dispose();
            }
        }
    }
}
