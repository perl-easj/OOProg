using System;

namespace VectorUtilities
{
    public static class DoubleExtensions
    {
        public static bool CloseEnough(this double a, double b, double tolerance = 0.0000001)
        {
            return (Math.Abs(a - b) < tolerance);
        }
    }
}