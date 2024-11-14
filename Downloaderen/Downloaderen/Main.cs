namespace Downloaderen;

using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Net;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

public partial class Main : MetroForm
{
    private string connectionString =
        $"SERVER=localhost;DATABASE=downloaderen;UID=root;PWD=;Convert Zero Datetime=True;Pooling=True;";
    
    public Main()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
        string username = textBox1.Text;
        string password = textBox2.Text;

        
        if (string.IsNullOrWhiteSpace(username) || username.Length < 8)
        {
            MessageBox.Show("Username must be at least 8 characters long.");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
        {
            MessageBox.Show("Password must be at least 8 characters long.");
            return;
        }
        
        var (loginResult, userId) = ValidateUser(username, password);
        if (loginResult == "Success")
        {
            MessageBox.Show("Login Success");
            // Save the userId as needed
            new Downloader(userId).Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show(loginResult);
        }
    }

    private void metroButton1_Click(object sender, EventArgs e)
    {
        // Register btn
        string username = textBox1.Text;
        string password = textBox2.Text;

        bool isRegistered = RegisterUser(username, password);
        if (isRegistered)
        {
            MessageBox.Show("User registered successfully");
        }
        else
        {
            MessageBox.Show("User registration failed");
        }
    }
    
    public bool RegisterUser(string username, string password)
    {
        byte[] passwordHash, salt;
        PasswordHelper.CreatePasswordHash(password, out passwordHash, out salt);

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO users (Username, PasswordHash, Salt) VALUES (@Username, @PasswordHash, @Salt)", conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@Salt", salt);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
    
    private (string, int) ValidateUser(string username, string password)
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("SELECT Id, PasswordHash, Salt FROM users WHERE Username = @Username", conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("Id");
                        byte[] storedHash = (byte[])reader["PasswordHash"];
                        byte[] storedSalt = (byte[])reader["Salt"];
                        byte[] hash = HashPassword(password, storedSalt);

                        if (storedHash.SequenceEqual(hash))
                        {
                            return ("Success", userId);
                        }
                        else
                        {
                            return ("Invalid password.", -1);
                        }
                    }
                    else
                    {
                        return ("Username not found.", -1);
                    }
                }
            }
        }
    }

    private byte[] HashPassword(string password, byte[] salt)
    {
        using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            return rfc2898.GetBytes(64);
        }
    }
}

public static class PasswordHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] salt)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            salt = new byte[16];
            rng.GetBytes(salt);
        }

        using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            passwordHash = rfc2898.GetBytes(64);
        }
    }
}