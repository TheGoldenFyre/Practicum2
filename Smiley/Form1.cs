using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smiley
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += tekenSmiley;
        }

        void tekenSmiley(object o, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            int x = 200, y = 0;

            Point[] points = { new Point(150 + x, 250 + y), new Point(225 + x, 275 + y), new Point(300 + x, 250 + y) };

            g.FillEllipse(Brushes.Yellow, new RectangleF(new Point(0 + x, 0 + y), new Size(400, 400))); //head
            g.FillEllipse(Brushes.Black, new RectangleF(new Point(150 + x, 150 + y), new Size(50, 50))); //lefteye
            g.FillEllipse(Brushes.Black, new RectangleF(new Point(300 + x, 150 + y), new Size(50, 50))); //righteye
            g.DrawCurve(new Pen(Brushes.Black, 15), points);
        }
    }
}
