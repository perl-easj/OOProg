using System;

namespace ShapesCompare.Original
{
    public class Circle : ShapeBase
    {
        public double X { get; }
        public double Y { get; }
        public double Radius { get; }

        public Circle(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override double Area
        {
            get { return Radius * Math.PI; }
        }
    }
}