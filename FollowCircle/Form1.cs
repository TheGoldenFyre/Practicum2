using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowCircle
{
    public partial class Form1 : Form
    {
        private Point mPos = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Paint += paint;
            this.MouseMove += mouseMove;
        }

        void paint(object o, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            double d, dy, dx, ey, ex, r = 100, k, eyeWidth = 40;
            int offsetX = 400, offsetY = 100;
            Point midpoint = new Point((int)(offsetX + r), (int)(offsetY + r));
            
            //Midpoint (100, 100)
            dx = (mPos.X - midpoint.X);
            dy = (mPos.Y - midpoint.Y);

            d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            k = r / d;

            ex = k * dx;
            ey = k * dy;


            g.DrawEllipse(new Pen(Brushes.Black), new Rectangle(0 + offsetX, 0 + offsetY, (int)(2 * r), (int)(2 * r)));
            g.FillEllipse(Brushes.Black, new Rectangle((int)(ex - eyeWidth / 2 + midpoint.X), (int)(ey - eyeWidth / 2 + midpoint.Y), (int)eyeWidth, (int)eyeWidth));

        }


        void mouseMove(object o, MouseEventArgs mea)
        {
            mPos = mea.Location;
            Invalidate();
        }
    }
}
