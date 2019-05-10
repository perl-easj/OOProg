using System;

namespace Canvas01.Shapes.Base
{
    public class ShapeSpeed
    {
        private XY _xy;

        public ShapeSpeed(XY xy = null)
        {
            _xy = xy ?? new XY();
        }

        public int X
        {
            get { return _xy.X; }
            set { _xy.X = value; }
        }

        public int Y
        {
            get { return _xy.Y; }
            set { _xy.Y = value; }
        }

        public double Velocity { get { return Math.Sqrt(X * X + Y * Y);  } }
    }
}