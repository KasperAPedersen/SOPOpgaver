namespace Downloaderen;

using MetroFramework.Controls;
using MetroFramework.Forms;
using MetroFramework;

partial class Main
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
        label2 = new MetroLabel();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        metroLabel1 = new MetroLabel();
        button3 = new MetroButton();
        metroButton1 = new MetroButton();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(7, 71);
        label2.Name = "label2";
        label2.Size = new Size(68, 19);
        label2.TabIndex = 5;
        label2.Text = "Username";
        // 
        // textBox1
        // 
        textBox1.BackColor = SystemColors.Window;
        textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox1.Location = new Point(7, 93);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(178, 33);
        textBox1.TabIndex = 6;
        // 
        // textBox2
        // 
        textBox2.BackColor = SystemColors.Window;
        textBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox2.Location = new Point(7, 158);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(178, 33);
        textBox2.TabIndex = 8;
        // 
        // metroLabel1
        // 
        metroLabel1.AutoSize = true;
        metroLabel1.Location = new Point(7, 136);
        metroLabel1.Name = "metroLabel1";
        metroLabel1.Size = new Size(63, 19);
        metroLabel1.TabIndex = 7;
        metroLabel1.Text = "Password";
        // 
        // button3
        // 
        button3.Location = new Point(7, 202);
        button3.Name = "button3";
        button3.Size = new Size(178, 52);
        button3.TabIndex = 9;
        button3.Text = "Login";
        button3.UseSelectable = true;
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // metroButton1
        // 
        metroButton1.Location = new Point(7, 257);
        metroButton1.Name = "metroButton1";
        metroButton1.Size = new Size(178, 52);
        metroButton1.TabIndex = 10;
        metroButton1.Text = "Register";
        metroButton1.UseSelectable = true;
        metroButton1.UseVisualStyleBackColor = true;
        metroButton1.Click += metroButton1_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(200, 324);
        Controls.Add(metroButton1);
        Controls.Add(button3);
        Controls.Add(textBox2);
        Controls.Add(metroLabel1);
        Controls.Add(textBox1);
        Controls.Add(label2);
        Name = "Main";
        Text = "Login";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MetroButton button1;
    private MetroButton button2;
    private MetroLabel label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private MetroLabel metroLabel1;
    private MetroButton button3;
    private MetroButton metroButton1;
}