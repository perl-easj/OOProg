using System;
using Canvas01.Shapes;
using Canvas01.Shapes.Base;

namespace Canvas01
{
    public class BouncingBallFactory
    {
        private static Random _gen = new Random();

        private XY _topLeft;
        private XY _bottomRight;
        private int _RadiusMin;
        private int _RadiusMax;
        private int _speedMin;
        private int _speedMax;

        public BouncingBallFactory(XY topLeft, XY bottomRight, int radiusMin, int radiusMax, int speedMin, int speedMax)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
            _RadiusMin = radiusMin;
            _RadiusMax = radiusMax;
            _speedMin = speedMin;
            _speedMax = speedMax;
        }

        public BouncingBall Create()
        {
            return new BouncingBall(_topLeft, _bottomRight, GenerateRadius(), GenerateSpeed());
        }

        private int GenerateSpeed()
        {
            return _gen.Next(_speedMin, _speedMax);
        }

        private int GenerateRadius()
        {
            return _gen.Next(_RadiusMin, _RadiusMax);
        }
    }
}