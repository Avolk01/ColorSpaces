using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Point : IComparable
    {
        public double X 
        { 
            get ; set; 
        }
        public double Y
        {
            get; set;
        }

        public double Z
        {
            get; set;
        }

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        } 

        static public double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) + (p1.Z - p2.Z) * (p1.Z - p2.Z));
        }        

        static public bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        static public bool operator !=(Point p1, Point p2)
        {
            return !(p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z);
        }
        static public bool operator <(Point p1, Point p2)
        {
            var d1 = Distance(p1, new Point(0, 0, 0));
            var d2 = Distance(p2, new Point(0, 0, 0));
            return d1 < d2 ? true : (Math.Abs(d1 - d2) <2 ) ? p1.X < p2.X : false;
        }

        static public bool operator >(Point p1, Point p2)
        {
            var d1 = Distance(p1, new Point(0, 0, 0));
            var d2 = Distance(p2, new Point(0, 0, 0));
            return d1 > d2 ? true : (Math.Abs(d1 - d2) < 2) ? p1.X > p2.X : false;
        }

        static public bool operator <=(Point p1, Point p2)
        {
            var d1 = Distance(p1, new Point(0, 0, 0));
            var d2 = Distance(p2, new Point(0, 0, 0));
            return d1 <= d2;
        }

        static public bool operator >=(Point p1, Point p2)
        {
            var d1 = Distance(p1, new Point(0, 0, 0));
            var d2 = Distance(p2, new Point(0, 0, 0));
            return d1 >= d2;
        }   

        public override string ToString()
        {
            return "{ X = " + X + ", Y = " + Y + ", Z = "+ Z + " }";
        }

        public int CompareTo(object obj)
        {
            var p = obj as Point; 
            return (this > p) ? 1 : (this < p) ? -1 : 0;
        }
    }
}
