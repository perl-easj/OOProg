namespace ShapesCompare.Original
{
    public class Square : ShapeBase
    {
        public double X { get; }
        public double Y { get; }
        public double SideLength { get; }

        public Square(double x, double y, double sideLength)
        {
            X = x;
            Y = y;
            SideLength = sideLength;
        }

        public override double Area
        {
            get { return SideLength * SideLength; }
        }
    }
}