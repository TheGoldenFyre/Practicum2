using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowMouse
{
    class Smiley
    {
        public Brush brush;
        public int breedte;
        public Point offset;
        public double vrolijkheid;

        public Smiley(Brush brush, int breedte, Point offset, double vrolijkheid)
        {
            this.brush = brush;
            this.breedte = breedte;
            this.offset = offset;
            this.vrolijkheid = vrolijkheid;
        }
    }

    public partial class Form1 : Form
    {

        private Point mouseCoords = new Point(0, 0);
        private List<Smiley> smileys = new List<Smiley>();

        public Form1()
        {
            InitializeComponent();

            this.Paint += paint;

            this.MouseClick += mouseHandler;
        }

        void paint(object o, PaintEventArgs pea)
        {
            for (int i = 0; i < smileys.Count; i++)
            {
                smiley(pea.Graphics, smileys[i].offset, smileys[i].breedte, smileys[i].brush, smileys[i].vrolijkheid);
            }
            
        }

        void mouseHandler(object o, MouseEventArgs mea)
        {
            this.mouseCoords = mea.Location;
            smileys.Add(new Smiley(Brushes.Green, 50, mouseCoords, 1.2)); 
            Invalidate();
        }

        void smiley(Graphics g, Point offset, int breedte, Brush br, double vrolijkheid)
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
            g.DrawCurve(new Pen(Brushes.Black, (int)((3.0 / 80.0) * breedte)), points);
        }
    }
}
