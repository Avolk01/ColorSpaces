using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{

    public partial class Form1 : Form
    {
        private Graphics g;
        private int width;
        private int height;
        private Point[] polyg;
        private Matrix funcMatrix;        
        public Form1()
        {
            InitializeComponent();

            var data = new double[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            funcMatrix = new Matrix(3, 3);
            funcMatrix.SetData(data);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            pictureBox1.Image = new Bitmap(width, height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            //g.ScaleTransform(1, -1);
            pictureBox1.Invalidate();
            ResetPoints();
            ResetFlags();
            WuLine(width / 2, 0, width / 2, height - 1, Color.Black);
            WuLine(0, height / 2, width - 1, height / 2, Color.Black);
        }

        private void ResetFlags()
        {
            line = false;
            polygon = false;
            scale = false;
            rotate = false;
            find = false;
            point = false;
            checkSide = false;
            nonConvex = false;
            convex = false;
        }

        private void ResetPoints()
        {   
            points = new Point[100];
            pointsSet = new bool[100];
            for (int i = 0; i < points.Length; i++)
            {
                pointsSet[i] = false;
                points[i] = new Point(-1, -1);
            }
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            ResetPoints();
            ResetFlags();
            hint.Visible = true;
            if (!point)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;            
            point = !point;
        }

        private bool line;
        private bool polygon;
        private bool point;
        private Point[] points;
        private bool[] pointsSet;

        private void lineButton_Click(object sender, EventArgs e)
        {
            var flag = find;
            ResetPoints();
            ResetFlags();
            hint.Visible = true;
            if (!line)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
            line = !line;
            if (flag)
                find = flag;           
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            ResetPoints();
            ResetFlags();
            hint.Visible = true;
            if (!polygon)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;            
            polygon = !polygon;            
            drawPolygonButton.Visible = true;
        }

        // НАЖАТИЯ НА ЭКРАН
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = -1;
            for (int i = pointsSet.Length - 1; i > -1; i--)
                if (pointsSet[i])
                {
                    index = i;
                    break;
                }

            if (convex)
            {
                convex = false;
                this.Cursor = Cursors.Default;               
                DrawPoint(e.X, e.Y, 2);
                convexLabel.Text = InsideConvex(e.X, e.Y).ToString();
                pictureBox1.Invalidate();
            }
            else if (nonConvex)
            {
                nonConvex = false;                
                this.Cursor = Cursors.Default;
                DrawPoint(e.X, e.Y, 2);
                nonConvexLabel.Text = InsideNonConvex(e.X, e.Y).ToString();
                pictureBox1.Invalidate();
            }
            else if (checkSide)
            {
                var left = CheckSide(e.X, e.Y);
                if (left)
                    checkSideTextBox.Text = "LEFT";
                else
                    checkSideTextBox.Text = "RIGHT";
                DrawPoint(e.X, e.Y, 2);                
                this.Cursor = Cursors.Default;
                //ResetPoints();
                //ResetFlags();
            }
            else if (scale)
            {
                scale = false;
                this.Cursor = Cursors.Default;
                var kx = 0.0;
                var ky = 0.0;
                pointXTextBox.Text = e.X.ToString();
                pointYTextBox.Text = e.Y.ToString();
                double.TryParse(scaleKXTextBox.Text, out kx);
                double.TryParse(scaleKYTextBox.Text, out ky);
                Scale(e.X, e.Y, kx, ky);
                DrawPolygon();                
            }
            else if (rotate)
            {
                rotate = false;
                this.Cursor = Cursors.Default;
                var phi = 0.0;                
                pointXTextBox.Text = e.X.ToString();
                pointYTextBox.Text = e.Y.ToString();
                double.TryParse(rotatePhiTextBox.Text, out phi);
                Rotate(e.X, e.Y, phi);
                DrawPolygon();                
            }
            else if (index > 1)
            {
                pointsSet[index] = false;
                pointsSet[index + 1] = true;
                points[index + 1] = new Point(e.X, e.Y);
            }
            else if (pointsSet[1])
            {

                pointsSet[1] = false;
                pointsSet[2] = true;
                points[2] = new Point(e.X, e.Y);

            }
            else if (pointsSet[0])
            {
                pointsSet[0] = false;
                pointsSet[1] = true;
                points[1] = new Point(e.X, e.Y);
                if (line)
                {
                    WuLine(points[0].X, points[0].Y, points[1].X, points[1].Y, Color.Black);
                    this.Cursor = Cursors.Default;
                    if (!find)
                        p2 = points[1];                    
                    pictureBox1.Invalidate();
                    if (find)
                    {
                        var p = FindIntersection();                        
                        DrawPoint(p.X, p.Y, 3);
                        DrawAdditionalLines(p);                        
                        ResetPoints();
                        ResetFlags();
                    }
                    line = false;                    
                    hint.Visible = false;
                }
            }
            else if (line)
            {
                pointsSet[0] = true;
                points[0] = new Point(e.X, e.Y);               
                if(!find)                
                    p1 = points[0];       
            }
            else if (point)
            {
                pointsSet[0] = true;
                points[0] = new Point(e.X, e.Y);
                DrawPoint(points[0].X, points[0].Y, 3);                
                this.Cursor = Cursors.Default;
                point = false;                
                hint.Visible = false;
            }
            else if (polygon)
            {
                pointsSet[0] = true;
                points[0] = new Point(e.X, e.Y);
            }
            pictureBox1.Invalidate();
        }

        //Рисование линии
        private void WuLine(int x0, int y0, int x1, int y1, Color clr)
        {
            polyg = new Point[2];
            polyg[0] = new Point(x0, y0);
            polyg[1] = new Point(x1, y1);

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
            DrawWUPoint(steep, x0, y0, 1, clr);
            DrawWUPoint(steep, x1, y1, 1, clr);
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawWUPoint(steep, x, (int)y, 1 - (y - (int)y), clr);
                DrawWUPoint(steep, x, (int)y + 1, y - (int)y, clr);
                y += gradient;
            }
        }
        private void DrawWUPoint(bool flag, int x, int y, double a, Color clr)
        {
            if (flag)
            {
                var t = x;
                x = y;
                y = t;
            }
            if (x < width-1 && x > 0 && y < height-1 && y > 0)
                (pictureBox1.Image as Bitmap).SetPixel(x, y, Color.FromArgb((int)(a * 255), clr));
        }

        private void DrawPoint(int x, int y, int size)
        {
            polyg = new Point[1];
            polyg[0] = new Point(x, y);
            for (int i = x - size; i <= x + size; i++)
                for (int j = y - size; j <= y + size; j++)
                    if (i >= 0 && i <= pictureBox1.Width)
                        if (j >= 0 && j <= pictureBox1.Height)
                        {
                            (pictureBox1.Image as Bitmap).SetPixel(i, j, Color.Black);
                            pictureBox1.Invalidate();
                        }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            dxTextBox.Text = 0.ToString();
            dyTextBox.Text = 0.ToString();            
            pointXTextBox.Text = 0.ToString();
            pointYTextBox.Text = 0.ToString();
            scaleKXTextBox.Text = 1.ToString();
            scaleKYTextBox.Text = 1.ToString();
            checkSideTextBox.Visible = false;
            WuLine(width / 2, 0, width / 2, height - 1, Color.Black);
            WuLine(0, height / 2, width - 1, height / 2, Color.Black);
            pictureBox1.Invalidate();
            ResetPoints();
            ResetFlags();
        }
        private void drawPolygonButton_Click(object sender, EventArgs e)
        {
            hint.Visible = false;
            polygon = false;
            drawPolygonButton.Visible = false;
            this.Cursor = Cursors.Default;
            polyg = new Point[100];
            DrawPolygon();
            pictureBox1.Invalidate();
            //ResetPoints();
        }

        private void DrawPolygon()
        {
            int i = 0;
            while (!pointsSet[i++])                
                WuLine(points[i - 1].X, points[i - 1].Y, points[i].X, points[i].Y, Color.Black);            
            WuLine(points[i - 1].X, points[i - 1].Y, points[0].X, points[0].Y, Color.Black);
        }

        private void dxdyButton_Click(object sender, EventArgs e)
        {
            double dx = 0;
            double.TryParse(dxTextBox.Text, out dx);
            double dy = 0;
            double.TryParse(dyTextBox.Text, out dy);
            var dxdyMatrix = new double[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { dx,-dy, 1 } };
            funcMatrix.SetData(dxdyMatrix);
            AlgorithWithMatrix();
            DrawPolygon();
            pictureBox1.Invalidate();
        }

        private Point GetPolygonCenter()
        {            
            int i = 0;
            var sumX = 0;
            var sumY = 0;
            var count = 0;
            while (!pointsSet[i++])
            {
                sumX += points[i - 1].X;
                sumY += points[i - 1].Y;
                count++;
            }
            sumX += points[i - 1].X;
            sumY += points[i - 1].Y;
            count++;
            return new Point(sumX/count, sumY/count);
        }

        private bool scale = false;

        private void AlgorithWithMatrix()
        {
            int i = 0;
            while (!pointsSet[i++])
            {
                var pointMatr1 = new Matrix(1, 3);
                var pointMatrData1 = new double[1, 3];
                pointMatrData1[0, 0] = points[i - 1].X;
                pointMatrData1[0, 1] = points[i - 1].Y;
                pointMatrData1[0, 2] = 1;
                pointMatr1.SetData(pointMatrData1);
                var res1 = pointMatr1.Mult(funcMatrix);
                points[i - 1] = new Point((int)res1.GetElem(0, 0), (int)res1.GetElem(0, 1));
            }
            var pointMatr = new Matrix(1, 3);
            var pointMatrData = new double[1, 3];
            pointMatrData[0, 0] = points[i - 1].X;
            pointMatrData[0, 1] = points[i - 1].Y;
            pointMatrData[0, 2] = 1;
            pointMatr.SetData(pointMatrData);
            var res = pointMatr.Mult(funcMatrix);
            points[i - 1] = new Point((int)res.GetElem(0, 0), (int)res.GetElem(0, 1));
        }

        private void Scale(int x, int y, double kx, double ky)
        {
            var dilatationMatrix = new double[3, 3] { { kx, 0, 0 }, { 0, ky, 0 }, { (1-kx)*x, (1-ky)*y, 1 } };
            funcMatrix.SetData(dilatationMatrix);
            AlgorithWithMatrix();
            DrawPolygon();
            pictureBox1.Invalidate();
        }

        private void scaleButton_Click(object sender, EventArgs e)
        {
            if (clickRB.Checked)
            {
                hint.Visible = true;
                if (!scale)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
                scale = !scale;
                line = false;
                rotate = false;
                polygon = false;
                point = false;
            }
            else 
            {
                var p = GetPolygonCenter();
                var kx = 0.0;
                var ky = 0.0;                
                double.TryParse(scaleKXTextBox.Text, out kx);
                double.TryParse(scaleKYTextBox.Text, out ky);
                Scale(p.X, p.Y, kx, ky);
                DrawPolygon();
            }
        }

        private void centerRB_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            pointXTextBox.Visible = false;
            pointYTextBox.Visible = false;                      

            clickRB.Checked = false;
            centerRB.Checked = true;
        }

        private void clickRB_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;            
            pointXTextBox.Visible = true;
            pointYTextBox.Visible = true;

            centerRB.Checked = false;
            clickRB.Checked = true;
        }

        private bool rotate = false;

        private void Rotate(int x, int y, double phi)
        {
            var ang = phi * Math.PI / 180;
            var sin = Math.Sin(ang);
            var cos = Math.Cos(ang);
            var t1 = -x * cos + y * sin + x;
            var t2 = -x * sin - y * cos + y;
            var dilatationMatrix = new double[3, 3] { { cos, sin, 0 }, { -sin, cos, 0 }, { t1, t2, 1 } };
            funcMatrix.SetData(dilatationMatrix);
            AlgorithWithMatrix();
            if (!find)
            {
                DrawPolygon();
                pictureBox1.Invalidate();
            }
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (clickRB.Checked)
            {
                hint.Visible = true;
                if (!rotate)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
                rotate = !rotate;
                scale = false;
                line = false;
                polygon = false;
                point = false;                             
            }
            else
            {
                var p = GetPolygonCenter();
                var phi = 0.0;                
                double.TryParse(rotatePhiTextBox.Text, out phi);                 
                Rotate(p.X, p.Y, phi);
                DrawPolygon();                
            }
        }

        private void rotateLineButton_Click(object sender, EventArgs e)
        {
            if (pointsSet[1])
            {
                var pi = 180;
                var a = points[0];
                var b = points[1];
                //for (int i = 0; i < 360; i++)                
                Rotate((a.X + b.X)/2, (a.Y+b.Y)/2,pi/2);                
            }
            
        }

        private bool find = false;
        Point p1;
        Point p2;

        private Vector FindNormalVector(Point p1, Point p2)
        {
            // A * X + B * Y + C = 0;
            // (y2-y1)*x + (x1-x2) * y + C = 0;
            return new Vector(p2.Y - p1.Y, p1.X - p2.X);
        }

        private Point FindIntersection()
        {
            var p3 = points[0];
            var p4 = points[1];
            var n = FindNormalVector(p3,p4);
            var ba = new Vector(p2.X - p1.X, p2.Y - p1.Y);
            var ac = new Vector(p1.X - p3.X, p1.Y - p3.Y);
            var t = -1*(n * ac / (n * ba));
            return new Point (((int)((1 - t) * p1.X + t * p2.X)),(int)((1 - t) * p1.Y + t * p2.Y));
        }

        // рисует дополнительные линии после нахождения точки пересечения
        private void DrawAdditionalLines(Point p)
        {
            if (p1.X > p2.X)
            {
                var t = p1;
                p1 = p2;
                p2 = t;
            }

            var p3 = points[0];
            var p4 = points[1];

            if (p3.X > p4.X)
            {
                var t = p3;
                p3 = p4;
                p4 = t;
            }            

            if (p.X < p1.X)
                WuLine(p.X, p.Y, p1.X, p1.Y, Color.Red);
            else if (p.X > p2.X)
                WuLine(p.X, p.Y, p2.X, p2.Y, Color.Red);

            if (p.X < p3.X)
                WuLine(p.X, p.Y, p3.X, p3.Y, Color.Red);
            else if (p.X > p4.X)
                WuLine(p.X, p.Y, p4.X, p4.Y, Color.Red);            
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            if (pointsSet[1])
            {
                find = !find;
                lineButton_Click(sender, e);
                //hint.Text = "!!!!!!!!";
            }
        }

        private bool checkSide = false;

        private bool CheckSide(int x, int y) // left
        {
            var v1 = new Vector(p2, p1);
            var v2 = new Vector(new Point(x,y), p1);
            var res = v2.GetY() * v1.GetX() - v2.GetX() * v1.GetY();
            return res < 0;
        }

        private void checkSideButton_Click(object sender, EventArgs e)
        {
            if (pointsSet[1])
            {
                if (!checkSide)
                    this.Cursor = Cursors.Hand;
                else
                    this.Cursor = Cursors.Default;
                checkSideTextBox.Visible = true;
                checkSide = !checkSide;                             
            }
        }

        private void checkSideTextBox_Click(object sender, EventArgs e)
        {

        }


        private bool convex = false;
        private void convexButton_Click(object sender, EventArgs e)
        {
            ResetFlags();
            if (!convex)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
            convex = !convex;
            hint.Visible = true;
        }

        private bool InsideConvex(int x, int y)
        {
            int i = 0;
            p1 = points[i];
            p2 = points[i+1];
            var prev = CheckSide(x, y);
            var result = true;
            while (!pointsSet[i++])      
            {
                if (!result)
                    return false;
                p1 = points[i - 1];
                p2 = points[i];
                var cur = CheckSide(x, y);
                result = (prev == cur);
                prev = cur;
            }
            p1 = points[i - 1];
            p2 = points[0];
            result = (prev == CheckSide(x, y));
            return result;            
        }

        private bool InsideNonConvex(int x, int y)
        {
            int count = 0;
            int count1 = 1;
            int i = 0;
            while (!pointsSet[i++])
            {
                p1 = points[i-1];
                p2 = points[i];
                if ((Math.Min(p1.X, p2.X) >= x) || (Math.Min(p1.X, p2.X) <= x && Math.Max(p1.X, p2.X) >= x))
                {
                    if (y >= Math.Min(p1.Y, p2.Y) && y < Math.Max(p1.Y, p2.Y) && !(p1.Y == p2.Y))
                    {
                        if (p1.Y > p2.Y)
                        {
                            var t = p1;
                            p1 = p2;
                            p2 = t;
                        }
                        var left = !CheckSide(x, y);
                        if (left)
                            count++;
                    }
                }                
            }
            p1 = points[i - 1];
            p2 = points[0];
            if ((Math.Min(p1.X, p2.X) >= x) || (Math.Min(p1.X, p2.X) <= x && Math.Max(p1.X, p2.X) >= x))
            {
                if (y >= Math.Min(p1.Y, p2.Y) && y < Math.Max(p1.Y, p2.Y) && !(p1.Y == p2.Y))
                {
                    if (p1.Y > p2.Y)
                    {
                        var t = p1;
                        p1 = p2;
                        p2 = t;
                    }
                    var left = !CheckSide(x, y);
                    if (left)
                        count++;
                }
            }
            count1++;
            
            return (count % 2 == 1);
        }

        private bool nonConvex = false;
        private void nonConvexButton_Click(object sender, EventArgs e)
        {
            ResetFlags();
            if (!nonConvex)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
            nonConvex = !nonConvex;
            hint.Visible = true;
        }
    }
}
