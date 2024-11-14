namespace Downloaderen
{
    partial class Downloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button2 = new MetroFramework.Controls.MetroButton();
            button1 = new MetroFramework.Controls.MetroButton();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(7, 136);
            button2.Name = "button2";
            button2.Size = new Size(234, 67);
            button2.TabIndex = 3;
            button2.Text = "Manage";
            button2.UseSelectable = true;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(7, 63);
            button1.Name = "button1";
            button1.Size = new Size(234, 67);
            button1.TabIndex = 2;
            button1.Text = "Download";
            button1.UseSelectable = true;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Downloader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 219);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Downloader";
            Text = "Downloader";
            Load += Downloader_Load;
            ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton button1;
    }
}