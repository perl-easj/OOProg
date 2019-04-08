using ReFac.TowardsAdapter.Shared.Interfaces;

namespace ReFac.TowardsAdapter.Shared.Shapes
{
    public class Circle : IShape
    {
        public Point Center { get; }
        public double Radius { get; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }
    }
}