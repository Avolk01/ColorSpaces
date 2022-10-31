using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Polyhedron
    {

        public double Value
        {
            get; set;
        }
        public List<Point> Points
        {
            get; set;
        }

        public void SetPoints(Point[] ps)
        {
            Points = ps.ToList();
        }
        public List<Polygon> Polygons
        {
            get;
        }
        public int Count
        {
            get;
        }

        public int Size
        {
            get;
        }

        public Polyhedron(Polygon[] polygons, double val)
        {
            Value = val;
            this.Polygons = polygons.ToList();
            Count = polygons.Length;
            Points = new List<Point>();            
            foreach(Polygon poly in polygons)            
                foreach(Point p in poly.Points)                
                    Points.Add(p);                
            Points = Points.Distinct().ToList();
            foreach (var p in Points)
            {
                Console.WriteLine(p.ToString());
            }           
        }

        private bool IsPolygon(Point[] points)
        {            
            var l = new List<Line>();
            if (points[0] == points[1] || points[1] == points[2] || points[2] == points[0])            
                return false;
            
            var size = points.Length;


            if (size == 3)
            {
                l.Add(new Line(points[0], points[1]));
                l.Add(new Line(points[1], points[2]));
                l.Add(new Line(points[2], points[0]));
            }

            if (size == 4)
            {
                if (points[0] == points[3] || points[1] == points[3] || points[2] == points[3])
                    return false;
                l.Add(new Line(points[0], points[1]));
                l.Add(new Line(points[1], points[2]));
                l.Add(new Line(points[2], points[3]));
                l.Add(new Line(points[3], points[0]));
            }

            if (size == 5)
            {
                if (points[0] == points[3] || points[1] == points[3] || points[2] == points[3])
                    if(points[0] == points[4] || points[1] == points[4] || points[2] == points[4] || points[3] == points[4])
                        return false;
                l.Add(new Line(points[0], points[1]));
                l.Add(new Line(points[1], points[2]));
                l.Add(new Line(points[2], points[3]));
                l.Add(new Line(points[3], points[4]));
                l.Add(new Line(points[4], points[0]));
            }
            
            foreach (var line in l)            
                if(Math.Abs(line.Length() - Value) > Value*0.2 )
                    return false;          
            return true;
        }

        public Polyhedron(Point[] points, int size, double val)
        {
            Value = val;
            Size = size;
            var pols = new List<Polygon>();
            for (int i = 0; i < points.Count(); i++)
                for (int j = 0; j < points.Count(); j++)
                    for (int k = 0; k < points.Count(); k++)
                        if (size > 3) 
                        {
                            for (int l = 0; l < points.Count(); l++)
                                if (size > 4)
                                    for (int u = 0; u < points.Count(); u++)
                                    {                                        
                                        var ps = new Point[] { points[i], points[j], points[k], points[l], points[u] };
                                        if (IsPolygon(ps))
                                        {
                                            pols.Add(new Polygon(ps));                                            
                                        }
                                    }
                                else
                                {                                   
                                    var ps = new Point[] { points[i], points[j], points[k], points[l] };
                                    if (IsPolygon(ps))
                                    {
                                        pols.Add(new Polygon(ps));                                        
                                    }
                                }
                        }
                        else
                        {
                            var ps = new Point[] { points[i], points[j], points[k]};
                            if (IsPolygon(ps))
                                pols.Add(new Polygon(ps));
                        }

            Polygons = pols;
            Count = pols.Count();
            Points = points.ToList();
            
        }
    }
}
