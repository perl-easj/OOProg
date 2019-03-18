namespace ShapesCompare.Compliant
{
    public class Point : IShapeNoArea
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