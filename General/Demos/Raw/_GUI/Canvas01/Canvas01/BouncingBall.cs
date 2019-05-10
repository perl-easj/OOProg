using System;
using Canvas01.Shapes;
using Canvas01.Shapes.Base;

namespace Canvas01
{
    public class BouncingBall
    {
        private static Random _gen = new Random();

        private int _x;
        private int _y;
        private int _vx;
        private int _vy;
        private int _radius;
        private int _speed;

        private XY _topLeft;
        private XY _bottomRight;

        private int _xMin;
        private int _xMax;
        private int _yMin;
        private int _yMax;

        public BouncingBall(XY topLeft, XY bottomRight, int radius, int speed = 1)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
            _radius = radius;
            _speed = speed;

            _xMin = _topLeft.X + _radius;
            _yMin = _topLeft.Y + _radius;
            _xMax = _bottomRight.X - _radius;
            _yMax = _bottomRight.Y - _radius;

            _x = _gen.Next(_xMin + 1, _xMax);
            _y = _gen.Next(_yMin + 1, _yMax);
            _vx = _gen.Next(0, 100) < 50 ? _speed : -_speed;
            _vy = _gen.Next(0, 100) < 50 ? _speed : -_speed;
        }

        public void Move()
        {
            if (AtTop() || AtBottom())
            {
                TurnVertical();
            }

            if (AtLeft() || AtRight())
            {
                TurnHorizontal();
            }

            MoveVertical();
            MoveHorizontal();
        }

        public XY Position
        {
            get { return new XY(_x, _y); }
        }

        public int Radius
        {
            get { return _radius; }
        }

        private bool AtTop()
        {
            return _y <= _yMin;
        }

        private bool AtBottom()
        {
            return _y >= _yMax;
        }

        private bool AtLeft()
        {
            return _x <= _xMin;
        }

        private bool AtRight()
        {
            return _x >= _xMax;
        }

        private void MoveVertical()
        {
            _y += _vy;
        }

        private void MoveHorizontal()
        {
            _x += -_vx;
        }

        private void TurnVertical()
        {
            _vy = -_vy;
        }

        private void TurnHorizontal()
        {
            _vx = -_vx;
        }
    }
}