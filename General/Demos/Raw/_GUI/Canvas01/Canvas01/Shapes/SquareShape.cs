using Canvas01.Shapes.Base;

namespace Canvas01.Shapes
{
    public class SquareShape : RectangleShape
    {
        public SquareShape(XY topLeft, double sideLength, double tilt = 0) 
            : base(topLeft, sideLength, sideLength, tilt)
        {
        }
    }
}