using System.Drawing;

namespace Indiv1_Andrew
{
  
    internal class Line
    {
        private Point p1, p2;
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }


        /// <summary>
        /// ax + by + c = 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Line(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            p1 = new Point(0, (int)(-c / b));
            p2 = new Point((int)(-c / a), 0);
        }

        /// <summary>
        /// Уравнение прямой через две точки
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public Line(Point p1, Point p2)
        {
            a = p1.Y - p2.Y;
            b = p2.X - p1.X;
            c = -p2.X * p1.Y + p2.Y * p1.X;
            this.p1 = p1;
            this.p2 = p2;
        }   

        public bool LeftSide(Point p)
        {
            var x1 = p2.X - p1.X;
            var y1 = p2.Y - p1.Y;
            var x2 = p.X - p2.X;
            var y2 = p.Y - p2.Y;
            var res = y2 * x1 - x2 * y1;
            return res < 0;
        }
    }
}
