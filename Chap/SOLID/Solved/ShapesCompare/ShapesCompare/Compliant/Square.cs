namespace ShapesCompare.Compliant
{
    public class Square : ShapeBase
    {
        public double X { get; }
        public double Y { get; }
        public PositiveDouble SideLength { get; }

        public Square(double x, double y, PositiveDouble sideLength)
        {
            X = x;
            Y = y;
            SideLength = sideLength;
        }

        public override PositiveDouble Area
        {
            get { return new PositiveDouble(SideLength.Value * SideLength.Value); }
        }
    }
}