using System;
using System.Collections.Generic;
using System.Linq;

namespace VectorUtilities
{
    /// <summary>
    /// This class models a simple 2-dimensional vector,
    /// with an X- and Y-coordinate.
    /// </summary>
    public class Vector
    {
        #region Standard Vector functionality
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        #endregion

        #region Operator Overloads
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static bool operator >=(Vector a, Vector b)
        {
            return a.Length >= b.Length;
        }

        public static bool operator <=(Vector a, Vector b)
        {
            return a.Length <= b.Length;
        }
        #endregion
    }
}