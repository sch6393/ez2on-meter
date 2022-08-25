using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ez2on_meter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox.Image = Form1.m_bitmap;
            timer.Interval = Form1.m_iInterval;
            timer.Start();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Image = Form1.m_bitmap;
            timer.Interval = Form1.m_iInterval;
        }
    }
}
