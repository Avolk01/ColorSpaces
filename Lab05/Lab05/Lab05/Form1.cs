using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05
{
    public partial class Form1 : Form
    {
        Graphics g;
        double pi = Math.PI;
        Polyhedron figure;
        Polyhedron cube;
        private Matrix funcMatrix;
        double gold = (1 + Math.Sqrt(5)) / 2;
        Pen pen = new Pen(Color.LightBlue, 1);

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            ResetCube(0,0,0,200);
            //g.ScaleTransform(1,-1);
            funcMatrix = new Matrix(4, 4);            
            g.TranslateTransform(400,300);
            figureBox.Items.Add("Куб");
            figureBox.Items.Add("Тетраэдр");
            figureBox.Items.Add("Октаэдр");
            figureBox.Items.Add("Икосаэдр");
            figureBox.Items.Add("Додекаэдр");
        }

        private void ResetCube(int startX, int startY, int startZ, int length)
        {
            var r = length;
            var p1 = new Point(startX-r/2, startY-r/2, startZ-r/2);
            var p2 = new Point(p1.X + r, p1.Y, p1.Z);
            var p3 = new Point(p1.X + r, p1.Y + r, p1.Z);
            var p4 = new Point(p1.X, p1.Y + r, p1.Z);
            var p5 = new Point(p1.X, p1.Y, p1.Z + r);
            var p6 = new Point(p2.X, p2.Y, p2.Z + r);
            var p7 = new Point(p3.X, p3.Y, p3.Z + r);
            var p8 = new Point(p4.X, p4.Y, p4.Z + r);
            //cube = new Polyhedron(new Point[] { p1, p2, p3, p4, p5, p6, p7, p8 }, 4, r);
            var pol = new Polygon[6];
            pol[0] = new Polygon(new Point[] { p1, p2, p3, p4 });
            pol[1] = new Polygon(new Point[] { p2, p1, p5, p6 });
            pol[2] = new Polygon(new Point[] { p3, p2, p6, p7 });
            pol[3] = new Polygon(new Point[] { p4, p3, p7, p8 });
            pol[4] = new Polygon(new Point[] { p1, p4, p8, p5 });
            pol[5] = new Polygon(new Point[] { p5, p6, p7, p8 });  
            cube = new Polyhedron(pol, r);            
        }

        private Polyhedron GetPolyhedron(string name)
        {
            switch (name)
            {
                case "Куб": ResetCube(0,0,0,200); return cube;
                case "Тетраэдр": return GetTet();
                case "Октаэдр": return GetPolyhedronCenters(cube,4); ;
                case "Икосаэдр": return GetIcos();
                case "Додекаэдр": return GetPolyhedronCenters(GetIcos(), 5);
                default:
                    return cube;
            }
        }

        private Polyhedron GetTet()
        {
            var points = new List<Point>();
            points.Add(cube.Points[0]);
            points.Add(cube.Points[2]);
            points.Add(cube.Points[5]);
            points.Add(cube.Points[7]);
            return new Polyhedron(points.ToArray(), 3, Point.Distance(points[0], points[1]));
        }

        private Polyhedron GetPolyhedronCenters(Polyhedron polyh, int size)
        {
            var ps = new List<Point>();
            foreach (var poly in polyh.Polygons)                        
                ps.Add(poly.GetPolygonCenter());  
           
            return new Polyhedron(ps.ToArray(), size, Point.Distance(ps[0], ps[1]));
        }

        private Polyhedron GetIcos()
        {
            var points = new List<Point>();
            var x = 0;
            var y = 0;
            var z = 0;
            var r = 100;
            points.Add(new Point((int)(x + gold * r), (int)(y + r), (int)(z)));
            points.Add(new Point((int)(x + gold * r), (int)(y - r), (int)(z)));
            points.Add(new Point((int)(x - gold * r), (int)(y - r), (int)(z)));
            points.Add(new Point((int)(x - gold * r), (int)(y + r), (int)(z)));
            points.Add(new Point((int)(x), (int)(y + gold * r), (int)(z + r)));
            points.Add(new Point((int)(x), (int)(y - gold * r), (int)(z + r)));
            points.Add(new Point((int)(x),  (int)(y - gold * r), (int)(z - r)));
            points.Add(new Point((int)(x), (int)(y + gold * r), (int)(z - r)));
            points.Add(new Point((int)(x + r), (int)(y), (int)(z + gold * r)));
            points.Add(new Point((int)(x + r), (int)(y),  (int)(z - gold * r)));
            points.Add(new Point((int)(x - r),  (int)(y), (int)(z - gold * r)));
            points.Add(new Point((int)(x - r), (int)(y), (int)(z + gold * r)));            
            return new Polyhedron(points.ToArray(), 3, 2*r);
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            figure = GetPolyhedron(figureBox.Text);
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            foreach (var pol in figure.Polygons)
            {
                var temp = pol.Points.Select((p) => new System.Drawing.Point((int)p.X, (int)p.Y)).ToArray<System.Drawing.Point>();
                g.DrawPolygon(pen, temp);
            }           
            pictureBox1.Invalidate();            
        }

        private void Rotate(int x, int y, int z)
        {
            var t = 0;
            if (x != 0)
                t = x;
            if (y != 0)
                t = y;
            if (z != 0)
                t = z;
            var phi = t * pi / 180 ;
            var sin = Math.Sin(phi);
            var cos = Math.Cos(phi);
            var dilatationMatrix1 = new double[4, 4] {  { 1, 0, 0, 0 }, 
                                                        { 0, cos, sin, 0 }, 
                                                        { 0, -sin, cos, 0 }, 
                                                        { 0, 0, 0, 1 } };
            var dilatationMatrix2 = new double[4, 4] {  { cos, 0, -sin, 0 }, 
                                                        { 0, 1, 0, 0 }, 
                                                        { sin, 0, cos, 0 }, 
                                                        { 0, 0, 0, 1 } };
            var dilatationMatrix3 = new double[4, 4] {  { cos, sin, 0, 0 }, 
                                                        { -sin, cos, 0, 0 }, 
                                                        { 0, 0, 1, 0 }, 
                                                        { 0, 0, 0, 1 } };
            if(x != 0)
                funcMatrix.SetData(dilatationMatrix1);
            if (y != 0)
                funcMatrix.SetData(dilatationMatrix2);
            if (z != 0)
                funcMatrix.SetData(dilatationMatrix3);

            AlgorithWithMatrix();
            Redraw();
            //Console.WriteLine(figure.Polygons.Count);
            //Console.WriteLine(figure.Points.Count);
        }

        private void Scale(double x, double y, double z)
        {
            var t = 0.0;
            if (x != 0)
                t = x;
            if (y != 0)
                t = y;
            if (z != 0)
                t = z;            
            var Matrix1 = new double[4, 4] {  { t, 0, 0, 0 },
                                              { 0, 1, 0, 0 },
                                              { 0, 0, 1, 0 },
                                              { 0, 0, 0, 1 } };
            var Matrix2 = new double[4, 4] {  { 1, 0, 0, 0 },
                                              { 0, t, 0, 0 },
                                              { 0, 0, 1, 0 },
                                              { 0, 0, 0, 1 } };
            var Matrix3 = new double[4, 4] {  { 1, 0, 0, 0 },
                                              { 0, 1, 0, 0 },
                                              { 0, 0, t, 0 },
                                              { 0, 0, 0, 1 } };
            if (x != 0)
                funcMatrix.SetData(Matrix1);
            if (y != 0)
                funcMatrix.SetData(Matrix2);
            if (z != 0)
                funcMatrix.SetData(Matrix3);

            AlgorithWithMatrix(t);
            Redraw();
            //Console.WriteLine(figure.Polygons.Count);
            //Console.WriteLine(figure.Points.Count);
        }

        private void Translate(double x, double y, double z)
        {
            var t = 0.0;
            if (x != 0)
                t = x;
            if (y != 0)
                t = y;
            if (z != 0)
                t = z;            
            var Matrix1 = new double[4, 4] {  { 1, 0, 0, 0 },
                                                        { 0, 1, 0, 0 },
                                                        { 0, 0, 1, 0 },
                                                        { t, 0, 0, 1 } };
            var Matrix2 = new double[4, 4] {  { 1, 0, 0, 0 },
                                                        { 0, 1, 0, 0 },
                                                        { 0, 0, 01, 0 },
                                                        { 0, t, 0, 1 } };
            var Matrix3 = new double[4, 4] {  { 1, 0, 0, 0 },
                                                        { 0, 1, 0, 0 },
                                                        { 0, 0, 1, 0 },
                                                        { 0, 0, t, 1 } };
            if (x != 0)
                funcMatrix.SetData(Matrix1);
            if (y != 0)
                funcMatrix.SetData(Matrix2);
            if (z != 0)
                funcMatrix.SetData(Matrix3);

            AlgorithWithMatrix();
            Redraw();
            //Console.WriteLine(figure.Polygons.Count);
            //Console.WriteLine(figure.Points.Count);
        }

        private void AlgorithWithMatrix(double scale = 1)
        {
           
            for (int i = 0; i < figure.Polygons.Count(); i++)            
            {
                for (int j = 0; j < figure.Polygons[i].Count; j++)
                {
                    var p = figure.Polygons[i].Points[j];
                    var pointMatr1 = new Matrix(1, 4);
                    var pointMatrData1 = new double[1, 4];
                    pointMatrData1[0, 0] = p.X;
                    pointMatrData1[0, 1] = p.Y;
                    pointMatrData1[0, 2] = p.Z;
                    pointMatrData1[0, 3] = 1;
                    pointMatr1.SetData(pointMatrData1);
                    var t = pointMatr1.Mult(funcMatrix);
                    //points.Add(new Point(t.GetElem(0, 0), t.GetElem(0, 1), t.GetElem(0, 2)));
                    figure.Polygons[i].Points[j] = new Point(t.GetElem(0, 0), t.GetElem(0, 1), t.GetElem(0, 2));
                }
            }                      
        }

        private void RotateViaVector(double l, double m, double n, double phi)
        {
            phi *= pi / 180;
            var sin = Math.Sin(phi);
            var cos = Math.Cos(phi);
            var matrix = new double[4, 4] {  { l*l+cos*(1-l*l), l*(1-cos)*m + n*sin, l*(1-cos)*n - m*sin, 0 },
                                              { l*(1-cos)*m - n*sin, m*m+cos*(1-m*m), m*(1-cos)*n + l*sin, 0 },
                                              { l*(1-cos)*n + m*sin, m*(1-cos)*n - l*sin, n*n + cos*(1-n*n), 0 },
                                              { 0, 0, 0, 1 } };

            funcMatrix.SetData(matrix);
            AlgorithWithMatrix();
            Redraw();            
        }


        private void Redraw()
        {
            g.Clear(Color.White);
            foreach (var pol in figure.Polygons)
            {
                var temp = pol.Points.Select((p) => new System.Drawing.Point((int)p.X, (int)p.Y)).ToArray<System.Drawing.Point>();
                g.DrawPolygon(pen, temp);
            }            
            pictureBox1.Invalidate();
        }

        private void rotateXButton_Click(object sender, EventArgs e)
        {
            Rotate(10, 0,0);
        }

        private void rotateYButton_Click(object sender, EventArgs e)
        {
            Rotate(0, 10, 0);
        }

        private void rotateZButton_Click(object sender, EventArgs e)
        {
            Rotate(0, 0, 10);
        }

        private void rotateZButton_MouseDown(object sender, MouseEventArgs e)
        {
            Rotate(0, 0, 10);
        }

        private void rotateYButton_MouseDown(object sender, MouseEventArgs e)
        {
            Rotate(0, 10, 0);
        }

        private void rotateXButton_MouseDown(object sender, MouseEventArgs e)
        {
            Rotate(10, 0, 0);
        }

        private void scaleXButton_Click(object sender, EventArgs e)
        {
            Scale(1.1, 0, 0);
        }

        private void scaleYButton_Click(object sender, EventArgs e)
        {
            Scale(0, 1.1, 0);
        }

        private void scaleZButton_Click(object sender, EventArgs e)
        {
            Scale(0, 0, 1.1);
        }

        private void translateXButton_Click(object sender, EventArgs e)
        {
            Translate(10, 0, 0);
        }

        private void translateYButton_Click(object sender, EventArgs e)
        {
            Translate(0, 10, 0);
        }

        private void translateZButton_Click(object sender, EventArgs e)
        {
            Translate(0, 0, 10);
        }
    }
}
