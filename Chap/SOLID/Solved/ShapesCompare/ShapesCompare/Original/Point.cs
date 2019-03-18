namespace ShapesCompare.Original
{
    public class Point : ShapeBase
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override double Area
        {
            get { return 0; }
        }
    }
}