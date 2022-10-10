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
    public partial class Form4 : Form
    {

        List<Point> points;
        int count;
        Graphics g;
        Pen p = new Pen(Color.Black, 1);
        int n = 100;

        public Form4()
        {
            points = new List<Point>();
            count = 0;
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            cur = new Point(0, 0);
        }


        private bool isPressed = false;
        private Point cur;
        private int check = -1;

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            isPressed = false;
            RefreshPoints();
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                cur = e.Location;
                if (check != -1)
                    pictureBox1.Controls[check].Location = cur;
                pictureBox1.Invalidate();
            }
            Redraw();
            pictureBox1.Invalidate();
        }

        private void RefreshPoints()
        {
            var cnt = 1;
            points = new List<Point>();
            for (int i = 0; i < pictureBox1.Controls.Count; i++)
                if (pictureBox1.Controls[i] is RadioButton)
                {
                    pictureBox1.Controls[i].Text = "P" + cnt++;
                    points.Add(pictureBox1.Controls[i].Location);
                }
        }

        private int FindSelectedRB()
        {           
            for (int i = 0; i < pictureBox1.Controls.Count; i++)            
                if (pictureBox1.Controls[i] is RadioButton)
                    if ((pictureBox1.Controls[i] as RadioButton).Checked)
                        return (i);           
            return -1;
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            isPressed = true;
            check = FindSelectedRB();
            cur = e.Location;
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (newPoint)
            {
                count++;
                var text = "P" + (count);
                CreateNewPoint(e.Location, text);
                newPoint = false;
                Cursor = Cursors.Default;
                Redraw();
            }            
        }        

        private void CreateNewPoint(Point p, string text)
        {
            var res = new RadioButton();
            res.Location = p;
            res.Parent = this;            
            pictureBox1.Controls.Add(res);
            res.Width = 50;
            res.Height = 15;
            res.Text = text;
            res.BackColor = Color.White;
            points.Add(res.Location);            
            res.Show();
        }

        private bool newPoint = false;
        private void addPointButton_Click(object sender, EventArgs e)
        {            
            Cursor = !newPoint ?  Cursors.Hand : Cursors.Default;
            newPoint = !newPoint;
        }

        private int Factorial(int n)
        {
            var res = 1;
            for (int i = 1; i <=n ; i++)            
                res *= i;
            return res;
        }

        private int Combination(int m, int n) // C m n
        {
            return Factorial(n) / (Factorial(m) * Factorial(n - m));
        } 

        private Point Bezier(double t, int count, Point[] points, int index)
        {

            var b = Combination(0, count) * Math.Pow(t, 0) * Math.Pow(1 - t, count - 0);
            var sumX = points[index].X*b;
            var sumY = points[index].Y*b;
            
            for (int i = 1; i <= count; i++)
            {                
                b = Combination(i, count) * Math.Pow(t, i) * Math.Pow(1 - t, count - i);
                if (index + i - 1 < points.Length)
                {
                    sumX += points[index + i - 1].X * b;
                    sumY += points[index + i - 1].Y * b;
                }else
                {
                    sumX += points[points.Length - 1].X * b;
                    sumY += points[points.Length - 1].Y * b;
                }
            }
            return new Point((int)sumX, (int)sumY);
        }

        private void DrawBezierLine(int count, Point[] points, int index)
        {
            var res = new Point[n];
            for (int i = 1; i <= n; i++) 
                res[i-1] = Bezier((double)i / n, count, points, index);            
            DrawPolygon(res);
        } 

        private void DrawPolygon(Point[] ps)
        {
            p.Color = Color.Red;
            p.Width = 2;
            for (int i = 0; i < ps.Length-1; i++)           
                g.DrawLine(p, ps[i], ps[i + 1]); 
            pictureBox1.Invalidate();
            p.Color = Color.Black;
            p.Width = 1;
        }

        private void DrawLines()
        {
            for (int i = 0; i < points.Count - 1; i++)
                g.DrawLine(p, points[i], points[i + 1]);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {   
            
        }

        private void Redraw()
        {
            if (count == 0)
                return;
            g.Clear(Color.White);
            DrawLines();
            if(count > 4)
            {
                var t = new List<Point>();
                for (int i = 0; i < count; i++)
                {
                    if (i > 2)
                        if ((i % 2) == 1)
                            t.Add(new Point((points[i].X + points[i - 1].X) / 2, (points[i].Y + points[i - 1].Y) / 2));
                    t.Add(points[i]);                   
                }                
                
                for (int i = 0; i < t.Count; i += 3)
                {                    
                    DrawBezierLine(4, t.ToArray(), i);
                }
            }
            else
                DrawBezierLine(this.count, this.points.ToArray(), 0);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (var x in pictureBox1.Controls)
                if (x is RadioButton)
                    if ((x as RadioButton).Checked)
                    {
                        pictureBox1.Controls.Remove((Control)x);
                        if (count > 0)
                            count--;
                        RefreshPoints();
                        Redraw();
                    }
        }

        private void Form4_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width - 140;
            pictureBox1.Height = this.Height - 50;
            pictureBox1.Image = new Bitmap(this.Width - 140, this.Height - 50);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }
    }
}
