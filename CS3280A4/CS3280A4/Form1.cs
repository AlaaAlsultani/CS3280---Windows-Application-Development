using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3280A4
{
    public partial class Form1 : Form
    {

        List<StringGraphic> GameMarkers;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(10, 10, 32, 32));
            e.Graphics.DrawString("O", new System.Drawing.Font("Arial", 85) , new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(150, 50));
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            groupBox1.Text = e.X + " " + e.Y;
        }
    }
}
