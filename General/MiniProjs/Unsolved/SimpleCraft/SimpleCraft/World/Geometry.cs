using System;

namespace SimpleCraft.World
{
    /// <summary>
    /// Helper class for doing geometric calculations
    /// </summary>
    public class Geometry
    {
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            double xDelta = x1 - x2;
            double yDelta = y1 - y2;

            return Math.Sqrt(xDelta * xDelta + yDelta * yDelta);
        }
    }
}