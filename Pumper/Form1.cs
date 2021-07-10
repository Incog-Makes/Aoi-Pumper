using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Pumper
{
    public partial class Form1 : Form
    {
        private bool _dragging;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        string pumpby = "";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.Filter = "exe files (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = @".";
            openFileDialog1.Title = "Select file to be pumped";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = string.Empty;
                textBox1.Text = openFileDialog1.FileName;
                FileInfo fi = new FileInfo(textBox1.Text);
            }
        }
        public void Pump(string pumptype)
        {
            try
            {
                var file = File.OpenWrite(textBox1.Text);
                var siz = file.Seek(0, SeekOrigin.End);
                var size = Convert.ToInt64(textBox2.Text);
                if(pumptype.Contains("kb"))
                {
                    decimal bite = size * 1024;
                    while (siz < bite)
                    {
                        siz++;
                        file.WriteByte(0);
                    }
                    file.Close();
                    MessageBox.Show("File Pumped");
                }
                else if(pumptype.Contains("mb"))
                {
                    decimal bite = size * 1024 * 1024;
                    while (siz < bite)
                    {
                        siz++;
                        file.WriteByte(0);
                    }
                    file.Close();
                    MessageBox.Show("File Pumped");
                }
                else
                {
                    decimal bite = size * 1024 * 1024 * 1024;
                    while (siz < bite)
                    {
                        siz++;
                        file.WriteByte(0);
                    }
                    file.Close();
                    MessageBox.Show("File Pumped");
                }
                
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            Pump(pumpby);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                pumpby = "kb";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                pumpby = "mb";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                pumpby = "gb";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple file pumper, with the options to pump with KB,MB or GB. \n " +
                "Be aware pumping large numbers may freeze the application, depending on your device. \n" +
                "Enjoy :)");
        }
    }
}
