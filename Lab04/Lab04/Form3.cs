using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class Form3 : Form
    {
        private List<Point> points;
        double R = 0.5;
        Graphics g;
        Point pLeft = new Point();
        Point pRight = new Point();
        public Form3()
        {
            
            points = new List<Point>();
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pLeft = new Point(0, pictureBox1.Height - 1);
            pRight = new Point(pictureBox1.Width-1, pictureBox1.Height - 1);
            pictureBox1.Invalidate();
        }

        private void RisovatGora()
        {            
            foreach(var p in points)
            {

            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (start)
                if (p1.X == -1)
                    p1 = e.Location;
                else
                {
                    points = new List<Point>();
                    points.Add(pLeft);
                    p2 = e.Location;
                    Cursor = Cursors.Default;
                    start = false;
                    if(p1.X > p2.X)
                    {
                        var t = p1;
                        p1 = p2;
                        p2 = t;
                    }
                    WuLine(p1, p2, Color.Black);
                    WuLine(pLeft, p1, Color.Black);
                    WuLine(pRight, p2, Color.Black);
                    points.Add(p1);
                    points.Add(p2);
                    points.Add(pRight);
                    p1 = new Point(-1,-1);                 
                }                        
        }


        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private void drawHillButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            DrawHill();
            DrawPoints();
            DrawAdditionalLines();
        }

        private void DrawHill()
        {
            var rand = new Random();
            var TimePoints = new List<Point>();
            for (int i = 0; i < points.Count-1; i++)
            {
                TimePoints.Add(points[i]);
                var L = Distance(points[i], points[i + 1]);                
                var h = (int)(points[i].Y + points[i + 1].Y) / 2 + rand.Next((int)(-1 * R * L),(int)( R * L));                             
                TimePoints.Add(new Point((int)(points[i].X + points[i + 1].X) / 2, h));  
            }
            TimePoints.Add(points[points.Count - 1]);
            points = new List<Point>(TimePoints);            
        }

        private void DrawAdditionalLines()
        {
            for (int i = 0; i < points.Count; i++)            
                WuLine(points[i], new Point(points[i].X,pictureBox1.Height-1), Color.Black);                    
            pictureBox1.Invalidate();
        }

        private void DrawPoints()
        {
            for (int i = 0; i < points.Count - 1; i++)            
                WuLine(points[i], points[i + 1], Color.Black); 
            pictureBox1.Invalidate();
        }

        private void rTextBox_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(rTextBox.Text, out R);
        }

        private Point p1 = new Point(-1, -1);
        private Point p2 = new Point(-1, -1);
        private bool start = false;
        private void startLineButton_Click(object sender, EventArgs e)
        {
            start = !start;
            if (start)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;
        }


        private void DrawPoint(bool flag, int x, int y, double a, Color clr)
        {      
            if (flag)
            {
                var t = x;
                x = y;
                y = t;
            }           
            if(y>=pictureBox1.Height)
                y = pictureBox1.Height-1;
            if (y < 0)
                y = 0;
            (pictureBox1.Image as Bitmap).SetPixel(x, y, Color.FromArgb((int)(a*255), clr));
        }

        private void WuLine(Point p1, Point p2, Color clr)
        {
            var x0 = p1.X;
            var y0 = p1.Y;
            var x1 = p2.X;
            var y1 = p2.Y;
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                var t = x0;
                x0 = y0;
                y0 = t;
                t = x1;
                x1 = y1;
                y1 = t;
            }
            if (x0 > x1)
            {
                var t = x0;
                x0 = x1;
                x1 = t;
                t = y0;
                y0 = y1;
                y1 = t;
            }
            DrawPoint(steep, x0, y0, 1 ,clr);
            DrawPoint(steep, x1, y1, 1, clr);
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                var k1 = 1 - (y - (int)y);
                var k2 = y - (int)y;
                if (k1 > 1)
                    k1 = 1;
                if (k2 > 1)
                    k2 = 1;
                if (k1 < 0)
                    k1 = 0;
                if (k2 < 0)
                    k2 = 0;
                DrawPoint(steep, x, (int)y, k1, clr);
                DrawPoint(steep, x, (int)y + 1, k2, clr);
                y += gradient;
            }
            pictureBox1.Invalidate();
        }
    }
}
