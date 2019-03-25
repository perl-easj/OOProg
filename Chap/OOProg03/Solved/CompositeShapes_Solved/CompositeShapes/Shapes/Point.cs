using CompositeShapes.Interfaces;

namespace CompositeShapes.Shapes
{
    public class Point : IShape
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public void Resize(double factor)
        {
            // Perhaps a slightly strange definition of
            // "resize" for a Point, but these it is...
            X = X * factor;
            Y = Y * factor;
        }

        public Point Center
        {
            get { return this; }
        }

        public string ToCoord()
        {
            return $"({X:F2}, {Y:F2})";
        }

        public override string ToString()
        {
            return $"A Point at {ToCoord()}";
        }
    }
}