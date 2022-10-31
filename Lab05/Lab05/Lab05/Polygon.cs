using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Polygon
    {
        public List<Point> Points
        {
            get; set;
        }
        public List<Line> Lines
        {
            get; set;
        }
        public int Count
        {
            get;
        }

        public Polygon(Point[] points, Line[] lines)
        {
            this.Points = points.ToList();
            this.Lines = lines.ToList();
            Count = points.Length;
        }

        public Polygon(Point[] points)
        {
            this.Points = points.ToList();
            ResetLines(points);
            Count = Lines.Count();
        }

        public Polygon(Line[] lines)
        {
            this.Lines = lines.ToList();
            ResetPoints(lines);
            Count = Points.Count();
        }

        public void SetLines(Line[] ls)
        {
            Lines = ls.ToList();
            ResetPoints(ls);                        
        }       

        public void SetPoint(Point[] ps)
        {
            Points = ps.ToList();
            ResetLines(ps);
        }

        private void ResetLines(Point[] ps)
        {
            Lines = new List<Line>();
            for (int i = 0; i < ps.Length - 1; i++)
                Lines.Add(new Line(ps[i], ps[i + 1]));
            Lines.Add(new Line(ps[ps.Length - 1], ps[0]));
        }

        private void ResetPoints(Line[] ls)
        {
            Points = new List<Point>();
            foreach (var line in Lines)
                Points.Add(line.P1);
        }

        public Point GetPolygonCenter()
        {
            var sumX = 0.0;
            var sumY = 0.0;
            var sumZ = 0.0;
            foreach(var p in Points)
            {
                sumX += p.X;
                sumY += p.Y;
                sumZ += p.Z;
            }
            sumX /= Count;
            sumY /= Count;
            sumZ /= Count;
            return new Point((int)sumX, (int)sumY, (int)sumZ);
        }
    }
}
