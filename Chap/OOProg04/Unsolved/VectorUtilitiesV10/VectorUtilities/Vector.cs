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
        // TODO - implement overloading of operators + and -

        // TODO - implement overloading of operator *

        // TODO - implement overloading of operators >= and <=
        #endregion
    }
}