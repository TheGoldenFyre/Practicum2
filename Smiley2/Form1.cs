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
            this.Paint += teken;
        }

        void teken(object o, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    Smiley(g, new Point(75 * j, 75 * i), 50, Brushes.Green, 1.2);
                }
            }

        }

        void Smiley(Graphics g, Point offset, int breedte, Brush br, double vrolijkheid)
        {
            int x = offset.X, y = offset.Y;

            Point[] points = { new Point((int)((3.0/8.0) * breedte) + x, (int)((5.0 / 8.0) * breedte + y)),
                new Point((int)((9.0 / 16.0) * breedte) + x, (int)(vrolijkheid * (5.0 / 8) * breedte + y)),
                new Point((int)((6.0 / 8.0) * breedte) + x, (int)((5.0 / 8.0) * breedte + y)) };

            g.FillEllipse(br, new RectangleF(new Point(0 + x, 0 + y),
                new Size(breedte, breedte))); //head
            g.FillEllipse(Brushes.Black, new RectangleF(new Point((int)((3.0 / 8.0) * breedte) + x, (int)((3.0 / 8.0) * breedte) + y),
                new Size((int)((1.0 / 8.0) * breedte), (int)((1.0 / 8.0) * breedte)))); //lefteye
            g.FillEllipse(Brushes.Black, new RectangleF(new Point((int)((6.0 / 8.0) * breedte) + x, (int)((3.0 / 8.0) * breedte) + y),
                new Size((int)((1.0 / 8.0) * breedte), (int)((1.0 / 8.0) * breedte)))); //righteye
            g.DrawCurve(new Pen(Brushes.Black, (int)((3.0/80.0) * breedte)), points);
        }
    }
}
