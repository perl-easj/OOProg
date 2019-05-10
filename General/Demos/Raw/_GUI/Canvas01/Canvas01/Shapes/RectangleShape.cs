using System;
using Canvas01.Shapes.Base;
using Canvas01.Shapes.Interfaces;

namespace Canvas01.Shapes
{
    public class RectangleShape : IShape2D
    {
        public XY TopLeft { get; }
        public double SideLengthX { get; }
        public double SideLengthY { get; }
        public double Tilt { get; }

        public RectangleShape(XY topLeft, double sideLengthX, double sideLengthY, double tilt = 0.0)
        {
            TopLeft = topLeft;
            SideLengthX = sideLengthX;
            SideLengthY = sideLengthY;
            Tilt = tilt;
        }

        public bool Inside(double x, double y)
        {
            throw new NotImplementedException();
        }
    }
}