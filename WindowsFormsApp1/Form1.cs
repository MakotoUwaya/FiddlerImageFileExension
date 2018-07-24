using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                this.flowLayoutPanel1.Controls.Add(new PictureBox
                {
                    Image = new Bitmap(@"C:\Users\100508\Pictures\logo\qiita.png"),
                    SizeMode = PictureBoxSizeMode.AutoSize
                });
            }
        }
    }
}
