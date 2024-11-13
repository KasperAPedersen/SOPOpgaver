using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace WinFormsApp1
{
    public partial class ExcelToSQL : MetroForm
    {
        public ExcelToSQL()
        {
            InitializeComponent();
            this.panel1.DragEnter += new DragEventHandler(control_DragEnter);
            this.panel1.DragDrop += new DragEventHandler(control_DragDrop);
        }

        private void ExcelToSQL_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void control_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Allow copy effect
            }
            else
            {
                e.Effect = DragDropEffects.None; // Disallow drop
            }
        }

        private void control_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string filePath = file;
                Console.WriteLine(filePath);
            }
        }
    }
}
