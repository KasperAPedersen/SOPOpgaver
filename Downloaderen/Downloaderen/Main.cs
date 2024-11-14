namespace Downloaderen;

using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Net;

public partial class Main : MetroForm
{
    public Main()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        new Manage().Show();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        DownloadFile("https://dl.google.com/chrome/install/latest/chrome_installer.exe");
        /*Manage manageForm = new Manage();
        foreach (DataGridViewRow row in manageForm.dataGridView1.Rows)
        {
            if (row.Cells[0].Value != null)
            {
                string url = row.Cells[0].Value.ToString();
                DownloadFile("https://dl.google.com/chrome/install/latest/chrome_installer.exe");
            }
        }*/
    }
    
    private void DownloadFile(string url)
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                string fileName = Path.GetFileName(url);
                string downloadPath = Path.Combine("C:\\YourDownloadDirectory", fileName); // Specify your directory here
                client.DownloadFile(url, downloadPath);
                MessageBox.Show($"Downloaded {fileName} successfully.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error downloading file: {ex.Message}");
        }
    }
}