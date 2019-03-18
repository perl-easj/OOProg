using System;

namespace ShapesCompare.Compliant
{
    public class Circle : ShapeBase
    {
        public double X { get; }
        public double Y { get; }
        public PositiveDouble Radius { get; }

        public Circle(double x, double y, PositiveDouble radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override PositiveDouble Area
        {
            get { return new PositiveDouble(Radius.Value * Math.PI); }
        }
    }
}