using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indiv1_Andrew
{
    internal class Vector
    {
        Point a;
        Point b;
        double x;
        double y;
        public Vector(Point a, Point b)
        {
            this.a = a;
            this.b = b;
            x = b.X - a.X;
            y = b.Y - a.Y;
        }

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }

    }
}
