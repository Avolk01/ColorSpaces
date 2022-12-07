using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indiv1_Andrew
{
    public partial class Form1 : Form
    {
        Random rnd = new Random(0);
        private double eps = 0.001;
        private Graphics g;
        private List<Point> points;
        private Point[] andrew;
        private Pen p = new Pen(Color.Red, 3);

        public Form1()
        {
            InitializeComponent();
            points = new List<Point>();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);           
            g.Clear(Color.White);
        }

        private void Redraw()
        {
            g.Clear(Color.White);
            if (andrew.Length == 1)
                g.DrawEllipse(p, andrew[0].X - 1, andrew[0].Y - 1, 3, 3);
            else
                g.DrawPolygon(p, andrew);
            p.Color = Color.Black;
            foreach (var point in points)
                g.DrawEllipse(p, point.X - 1, point.Y - 1, 3, 3);
            p.Color = Color.Red;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (add)
            {
                (pictureBox1.Image as Bitmap).SetPixel(e.X, e.Y, Color.Red);
                points.Add(new Point(e.X, e.Y));
                andrew = Andrew(points.ToArray());
                Redraw();               
            }

            pictureBox1.Invalidate();
        }

        private bool add = false;

        private void addPointsButton_Click(object sender, EventArgs e)
        {
            add = !add;
            if (add)
                Cursor = Cursors.Hand;
            else
                Cursor = Cursors.Default;
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            var ps = Andrew(points.ToArray());
            g.DrawPolygon(p, ps);
            pictureBox1.Invalidate();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            points = new List<Point>();
            pictureBox1.Invalidate();
            this.Cursor = Cursors.Default;
            add = false;
        }


        private Point MinPointY(Point[] points)
        {
            var min = points[0];
            for (int i = 0; i < points.Length; i++)
                if (min.Y > points[i].Y)
                    min = points[i];
            return min;
        }

        private Point MaxPointY(Point[] points)
        {
            var max = points[0];
            for (int i = 0; i < points.Length; i++)
                if (max.Y < points[i].Y)
                    max = points[i];
            return max;
        }

        private Point MinPointX(Point[] points)
        {
            var min = points[0];
            for (int i = 0; i < points.Length; i++)
                if (min.X > points[i].X)
                    min = points[i];
            return min;            
        }

        private Point MaxPointX(Point[] points)
        {
            var max = points[0];
            for (int i = 0; i < points.Length; i++)
                if (max.X < points[i].X)
                    max = points[i];
            return max;
        }

        private void CheckX(List<Point> l, Point p, bool up)
        {
            for (int i = 0; i < l.Count; i++)
                if (p.X == l[i].X)
                {
                    l.RemoveAt(i);
                    l.Insert(i, new Point(p.X, p.Y));
                }
        }

        void Divide(Point[] points, List<Point> up, List<Point> down)
        {
            var left = MinPointX(points);   
            var right = MaxPointX(points);
            var line = new Line(left, right);
            foreach (var p in points)
            {
                //CheckX(up, p, true);
                //CheckX(down, p, false);
                var t = p.X * line.a + p.Y * line.b + line.c;
                if ( t < 0)
                    up.Add(p);
                else if(t > 0)
                    down.Add(p);
                else
                {
                    up.Add(p);
                    down.Add(p);
                } 
                    
            }
        }

        private bool CheckSide(Point p1, Point p2, Point p3) // left
        {
            return (p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y) >= 0;
        }

        private int CmpTo(Point p1, Point p2, int up)
        {
            if (p1.X == p2.X)
                return up * p1.Y.CompareTo(p2.Y);
            else
                return p1.X.CompareTo(p2.X);
        }

        private Point[] SimpleGraham(Point[] points, bool flag)
        {
            if (points.Length <= 2)
            {
                var result = new Point[points.Length];
                points.CopyTo(result,0);
                return result;
            }
            var down = new Point(0,0);
            var res = new List<Point>();
            foreach (var p in points)
                if(p.X != down.X && p.Y != down.Y)
                    res.Add(p);
            if (flag)
            {
                res.Sort((p1, p2) => p1.X.CompareTo(p2.X));               
                down = MaxPointY(points);
            }
            else
            {
                res.Sort((p1, p2) => p2.X.CompareTo(p1.X));
                down = MinPointY(points);
            }

            var s = new List<Point>();
            s.Add(down);
            s.Add(res[0]);
            for (int i = 1; i < res.Count(); i++)
            {            
                var p1 = s[s.Count() - 2];
                var p2 = s[s.Count() - 1];
                var p3 = res[i];               
                while (s.Count() > 1 && !CheckSide(p1, p2, p3))
                {
                    s.RemoveAt(s.Count() - 1);
                    if (s.Count() > 1)
                        p1 = s.ElementAt(s.Count-2);                   
                    p2 = s.ElementAt(s.Count-1);
                }
                s.Add(res[i]); 
            }
            s[0] = down;
            return s.ToArray();
        }

        private Point[] Merge(List<Point> l1, List<Point> l2)
        {
            var res = new List<Point>();
            var flag = l1.Count() < 3;
            var flag1 = l2.Count() < 3;
            if (flag)                         
                res.Add(l2[0]);
            if (flag1)
                res.Add(l1[0]);

            for (int i = 1; i < l1.Count()-1; i++)            
                res.Add(l1[i]);
            for (int i = 1; i < l2.Count()-1; i++)
                res.Add(l2[i]);            
            if (flag1)
                res.Add(l1[l1.Count()-1]);
            if (flag)
                res.Add(l2[l2.Count() - 1]);
            return res.ToArray();
        }               

        private Point[] Andrew(Point[] ps)
        {
            if (ps.Length < 3)
            {
                var res = new Point[ps.Length];
                for (int i = 0; i < ps.Length; i++)                
                    res[i] = ps[i];     
                return res;

            }
            var up = new List<Point>();            
            var down = new List<Point>();
            Divide(ps, up, down);
            up = SimpleGraham(up.ToArray(), true).ToList();
            down = SimpleGraham(down.ToArray(), false).ToList();
            return Merge(up,down);
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            var n = 0;
            int.TryParse(textBox1.Text, out n);
            for (int i = 0; i < n; i++)
            {
                var x = rnd.Next(2, 598);
                var y = rnd.Next(2, 598);
                points.Add(new Point(x, y));
            }
            andrew = Andrew(points.ToArray());
            Redraw();
        }
    }
}
