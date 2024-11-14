namespace Downloaderen;

using MetroFramework.Forms;
using MetroFramework.Controls;

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
        // download
    }
}