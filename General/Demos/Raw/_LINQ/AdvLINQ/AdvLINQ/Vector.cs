using System.Collections.Generic;

namespace AdvLINQ
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector() : this(0,0)
        {
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }



        public override string ToString()
        {
            return $"({X:F2} , {Y:F2})";
        }
    }

    public static class VectorLINQ
    {
        public static Vector Sum(this IEnumerable<Vector> source)
        {
            var sum = new Vector();
            foreach (var item in source)
            {
                sum = sum + item;
            }
            return sum;
        }
    }
}