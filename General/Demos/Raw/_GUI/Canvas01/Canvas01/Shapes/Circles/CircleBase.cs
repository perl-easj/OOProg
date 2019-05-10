using Canvas01.Shapes.Base;
using Canvas01.Shapes.Interfaces;

namespace Canvas01.Shapes.Circles
{
    public class CircleBase : IShape2D, IBoundingBox
    {
        public XY Center { get; }
        public int Radius { get; }

        public CircleBase(XY center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool Inside(double x, double y)
        {
            return false;
        }

        public XY BoundingBoxTopLeft
        {
            get
            {
                int xTL = Center.X - Radius;
                int yTL = Center.Y - Radius;
                return new XY(xTL, yTL);
            }
        }

        public XY BoundingBoxBottomRight
        {
            get
            {
                int xBR = Center.X + Radius;
                int yBR = Center.Y + Radius;
                return new XY(xBR, yBR);
            }
        }
    }
}