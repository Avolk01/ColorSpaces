using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form1 : Form
    {
        private Graphics g;
        public bool[,] pixelFill;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            colorDialog1.Color = Color.Black;
            pictureBox1.Height = 500;
            pictureBox1.Width = 500;
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            pixelFill = new bool[pictureBox1.Width, pictureBox1.Height];
            g.Clear(Color.White);
            pictureBox2.Hide();
        }
        private bool isPressed = false;
        private bool fill = false;
        private bool border = false;
        private Point Curr, Prev;        
        private int width = 0;
        private int height = 0;

        private void button1_Click(object sender, EventArgs e)
        {            
            openFileDialog1.ShowDialog();
            var img = Image.FromFile(openFileDialog1.FileName);
            ResetWindowSize(img.Width, img.Height);            
            pictureBox1.Image = new Bitmap (img);            
            g = Graphics.FromImage(pictureBox1.Image);  
        }

        private void ResetWindowSize(int width, int height)
        {   
            this.Width = width + 131;
            this.Height = height + 71;
            pictureBox1.Width = width;
            pictureBox1.Height = height;            
            this.width = width;
            this.height = height;
            pixelFill = new bool[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    pixelFill[i, j] = false;
            pictureBox2.Image = pictureBox1.Image;
            var g2 = Graphics.FromImage(pictureBox2.Image);
            g2.Clear(Color.White);
            pictureBox2.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!fill)
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
            fill = !fill;
            border = false;
            first = false;
            line = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetWindowSize(500, 500);
            pictureBox1.Image = new Bitmap(500, 500);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);            
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            label1.BackColor = colorDialog2.Color;
        }

        private void borderButton_Click(object sender, EventArgs e)
        {
            if (!border)
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
            border = !border;
            fill = false;
            first = false;
            line = false;
        }

        private Color borderColor;
       
        private Color GetColor(int x, int y)
        {
            Color clr = (pictureBox1.Image as Bitmap).GetPixel(x, y);
            return clr;
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (fill)
            {
                borderColor = GetColor(e.X, e.Y);
                Fill(e.X, e.Y);
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                        pixelFill[i, j] = false;
            }
            else if (border)
            {
                Color c = (pictureBox1.Image as Bitmap).GetPixel(e.X, e.Y);
                CreateBorder(FindBorder(e.X, e.Y, c));
            }
            else if (line)
            {
                first = true;
                p1.X = e.X;
                p1.Y = e.Y;
                line = false;
            } else if (first)
            {
                first = false;
                p2.X = e.X;
                p2.Y = e.Y;
                Bresenham4Line(g, Color.Black, p1.X, p1.Y, p2.X, p2.Y);
                pictureBox1.Invalidate();
                this.Cursor = Cursors.Default;
            }
            
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (isPressed && !fill && !border && !line && !first)
            {
                Prev = Curr;
                Curr = e.Location;
                Pen p = new Pen(colorDialog1.Color, 1);
                g.DrawLine(p, Prev, Curr);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            isPressed = true;
            Curr = e.Location;
        }

        private void Fill(int x, int y)
        {
            if (pixelFill[x, y])
                return;

            if (GetColor(x, y) == borderColor)
            {
                int xl = x, xr = x;

                while (--xl >= 0 && GetColor(xl, y) == borderColor) ;

                while (++xr < width && GetColor(xr, y) == borderColor) ;

                Pen p = new Pen(colorDialog2.Color);
                if (xl + 1 == xr - 1)
                {
                    (pictureBox1.Image as Bitmap).SetPixel(xl + 1, y, colorDialog2.Color);
                    pixelFill[xl + 1, y] = true;
                }
                else
                {
                    g.DrawLine(p, new Point(xl + 1, y), new Point(xr - 1, y));
                    for (int i = xl + 1; i <= xr - 1; i++)                    
                        pixelFill[i, y] = true;                    
                }

                pictureBox1.Invalidate();

                if (y - 1 >= 0)                
                    for (int i = xl + 1; i < xr; ++i)
                        Fill(i, y - 1);
                
                if (y + 1 < height)                
                    for (int i = xl + 1; i < xr; ++i)
                        Fill(i, y + 1);                 
            }
        }

        // Task 1B

        private void CreateBorder(List<Point> points)
        {
            var img = new Bitmap(pictureBox1.Image);
            foreach (var point in points)            
                img.SetPixel(point.X, point.Y, Color.Yellow); 
            pictureBox1.Image = img;
        }

        private int Border(int border, int x)
        {
            return Math.Max(0, Math.Min(border - 1, x));
        }

        private Point GetNearPixel(int x, int y, int direction)
        {
            
            switch (direction)
            {
                case 0:
                    return new Point(Border(width, x - 1), Border(height, y - 1));
                case 1:
                    return new Point(Border(width, x), Border(height, y - 1));
                case 2:
                    return new Point(Border(width, x + 1), Border(height, y - 1));
                case 3:
                    return new Point(Border(width, x + 1), Border(height, y));
                case 4:
                    return new Point(Border(width, x + 1), Border(height, y + 1));
                case 5:
                    return new Point(Border(width, x), Border(height, y + 1));
                case 6:
                    return new Point(Border(width, x - 1), Border(height, y + 1));
                case 7:
                    return new Point(Border(width, x - 1), Border(height, y));
                default:
                    return new Point(Border(width, x), Border(height, y - 1));
            }
        }        

        private List<Point> FindBorder(int x, int y, Color c)
        {            
            Queue<Point> points_to_visit = new Queue<Point>();
            List<Point> points = new List<Point>();
            HashSet<string> points_visited = new HashSet<string>();    
            int curr_x = 0;
            int curr_y = 0;
            points.Add(new Point(x, y));
            points_to_visit.Enqueue(new Point(x, y));
            points_visited.Add(x.ToString() + "," + y.ToString());
            while (points_to_visit.Count != 0)
            {
                curr_x = points_to_visit.Peek().X;
                curr_y = points_to_visit.Peek().Y;
                points_to_visit.Dequeue();               
                for (int i = 0; i < 8; i++)
                {
                    var point = GetNearPixel(curr_x, curr_y, (i + 8) % 8);
                    String str = point.X.ToString() + "," + point.Y.ToString();
                    if ((pictureBox1.Image as Bitmap).GetPixel(point.X, point.Y) == c)
                    {
                        if (!points_visited.Contains(str))
                        {                            
                            points_to_visit.Enqueue(point);
                            points_visited.Add(str);
                            points.Add(point);
                        }
                    }
                }                
            }
            return points;
        }

        //Метод, устанавливающий пиксел на форме с заданными цветом и прозрачностью
        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }
                
        static public void Bresenham4Line(Graphics g, Color clr, int x0, int y0, int x1, int y1)
        {
            int dx = (x1 > x0) ? (x1 - x0) : (x0 - x1);
            int dy = (y1 > y0) ? (y1 - y0) : (y0 - y1);
            var m = dy / dx; 
            int sx = (x1 >= x0) ? (1) : (-1);
            int sy = (y1 >= y0) ? (1) : (-1);

            if (m<=1)
            {
                int d = dy * 2 - dx;                
                int d1 = dy * 2;
                int d2 = (dy - dx) * 2;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0 + sx;
                int y = y0;
                for (int i = 1; i <= dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                        d += d1;
                    PutPixel(g, clr, x, y, 255);
                    x++;
                }
            }
            else
            {
                int d = dx * 2 - dy;
                int d1 = dx * 2;
                int d2 = (dx - dy) * 2;
                PutPixel(g, clr, x0, y0, 255);
                int x = x0;
                int y = y0 + sy;
                for (int i = 1; i <= dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                        d += d1;
                    PutPixel(g, clr, x, y, 255);
                    y++;
                }
            }
        }


        private bool first = false;
        private bool line = false;
        Point p1;
        Point p2;

        private void lineButton_Click(object sender, EventArgs e)
        {     
            if (!line)
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;
            line = !line;
            border = false;
            first = false;
            fill = false;
        }

    }
}