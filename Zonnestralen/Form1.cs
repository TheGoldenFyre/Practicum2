using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zonnestralen
{
    public class Straal
    {
        public Point beginPoint;
        public Point endPoint;

        public Straal(Point beginPoint, Point endPoint)
        {
            this.beginPoint = beginPoint;
            this.endPoint = endPoint;
        }
        
        public Straal()
        {
            this.beginPoint = new Point();
            this.endPoint = new Point();
        }
    }
    public partial class Form1 : Form
    {
        private Point mPos = new Point();
        private Pen pen = new Pen(Brushes.Black, 2);
        private List<Straal> stralen = new List<Straal>();
        private int sunWidth = 50;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.MouseMove += mouseMove;
            this.MouseClick += mouseClick;
            this.Paint += paint;
        }

        private void paint(object o, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            

            g.FillEllipse(Brushes.Black, new Rectangle(new Point(mPos.X - sunWidth / 2, mPos.Y - sunWidth / 2), new Size(sunWidth, sunWidth)));

            for (int i = 0; i < stralen.Count; i++)
            {
                g.DrawLine(pen, stralen[i].beginPoint, stralen[i].endPoint);
            }
        }

        private void mouseClick(object o, MouseEventArgs mea)
        {
            stralen.Add(new Straal());
            double xBetweenEndpoints = 0;
            if (stralen.Count != 1)
            {
                xBetweenEndpoints = this.ClientSize.Width / (stralen.Count - 1);

                for (int i = 0; i < stralen.Count; i++)
                {
                    stralen[i].beginPoint = mPos;
                    stralen[i].endPoint = new Point((int)Math.Round(i * xBetweenEndpoints), this.ClientSize.Height);
                }
            }
            else
            {
                stralen[0].endPoint = new Point(this.ClientSize.Width / 2, this.ClientSize.Height);
            }    
        }

        private void mouseMove(object o, MouseEventArgs mea)
        {
            mPos = mea.Location;

            for (int i = 0; i < stralen.Count; i++)
            {
                stralen[i].beginPoint = mPos;
            }

            Invalidate();
        }
    }
}
