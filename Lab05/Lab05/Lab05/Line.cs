using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class Line
    {
        public Point P1
        {
            get; set;
        }
        public Point P2
        {
            get; set;
        }

        public Line(Point p1, Point p2)
        {
            this.P1 = p1;
            this.P2 = p2;            
        }

        public double Length()
        {
            return Point.Distance(P1, P2);
        }

    }
}
