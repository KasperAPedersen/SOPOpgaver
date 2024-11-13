using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WinFormsApp1;

partial class ProduktDatabase
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new MetroButton();
        button2 = new MetroButton();
        button3 = new MetroButton();
        dataGridView1 = new DataGridView();
        metroButton1 = new MetroButton();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(303, 26);
        button1.Name = "button1";
        button1.Size = new Size(113, 49);
        button1.TabIndex = 4;
        button1.Text = "Tilføj";
        button1.UseSelectable = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(422, 26);
        button2.Name = "button2";
        button2.Size = new Size(113, 49);
        button2.TabIndex = 4;
        button2.Text = "Rediger";
        button2.UseSelectable = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(541, 26);
        button3.Name = "button3";
        button3.Size = new Size(113, 49);
        button3.TabIndex = 4;
        button3.Text = "Slet";
        button3.UseSelectable = true;
        button3.Click += button3_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.BackgroundColor = Color.White;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(20, 81);
        dataGridView1.MultiSelect = false;
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new Size(753, 356);
        dataGridView1.TabIndex = 3;
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        // 
        // metroButton1
        // 
        metroButton1.Location = new Point(660, 26);
        metroButton1.Name = "metroButton1";
        metroButton1.Size = new Size(113, 49);
        metroButton1.TabIndex = 5;
        metroButton1.Text = "Excel";
        metroButton1.UseSelectable = true;
        metroButton1.Click += metroButton1_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(783, 450);
        Controls.Add(metroButton1);
        Controls.Add(dataGridView1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "ProduktDatabase";
        Text = "Produkt Database";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private MetroButton button1;
    private DataGridView dataGridView1;
    private MetroButton button2;
    private MetroButton button3;
    private MetroButton metroButton1;
}