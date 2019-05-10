using System;
using Canvas01.Shapes.Base;
using Canvas01.Shapes.Interfaces;

namespace Canvas01.Shapes.Circles
{
    public class MoveableCircle : CircleBase, IMoveableShape
    {
        private IMoveableShape _moveableShape;

        public MoveableCircle(XY center, int radius, IMoveableShape moveableShape)
            : base(center, radius)
        {
            _moveableShape = moveableShape;
        }

        public ShapeSpeed Speed
        {
            get { return _moveableShape.Speed;}
            set { _moveableShape.Speed = value; }
        }

        public int SpeedX
        {
            get { return _moveableShape.Speed.X; }
            set { _moveableShape.Speed.X = value; }
        }

        public int SpeedY
        {
            get { return _moveableShape.Speed.Y; }
            set { _moveableShape.Speed.Y = value; }
        }

        public void Move()
        {
            Center.X += _moveableShape.SpeedX;
            Center.Y += _moveableShape.SpeedX;
        }

        public void MoveTowards(XY point)
        {
            throw new NotImplementedException();
        }
    }
}