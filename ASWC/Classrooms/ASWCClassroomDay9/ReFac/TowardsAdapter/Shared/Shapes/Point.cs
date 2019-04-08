using ReFac.TowardsAdapter.Shared.Interfaces;

namespace ReFac.TowardsAdapter.Shared.Shapes
{
    public class Point : IShape
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}