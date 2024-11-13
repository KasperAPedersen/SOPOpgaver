using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Ny : Form
    {
        private static readonly string Conn = $"SERVER=localhost;DATABASE=cbz;UID=root;PWD=;Convert Zero Datetime=True;Pooling=True;";

        public Ny()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(Conn))
            {
                connection.Open();
                
                string query = $"INSERT INTO tablename (Producent_navn, Producent_adresse, Vare_nummer, Vare_tekst, Kategori, Materiale, Lager_beholdning) VALUES (@a, @b, @c, @d, @e, @f, @h)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@a", textBox1.Text);
                    command.Parameters.AddWithValue("@b", textBox2.Text);
                    command.Parameters.AddWithValue("@c", textBox3.Text);
                    command.Parameters.AddWithValue("@d", textBox4.Text);
                    command.Parameters.AddWithValue("@e", textBox5.Text);
                    command.Parameters.AddWithValue("@f", textBox6.Text);
                    command.Parameters.AddWithValue("@h", textBox7.Text);

                    int rowsAffected = command.ExecuteNonQuery();
                }
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
