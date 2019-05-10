using Canvas01.Shapes.Interfaces;

namespace Canvas01.Shapes.Base
{
    public abstract class MoveableShapeImpl : IMoveableShape
    {
        private ShapeSpeed _speed;

        protected MoveableShapeImpl(XY xySpeed = null)
        {
            _speed = xySpeed != null ? new ShapeSpeed(xySpeed) : new ShapeSpeed();
        }

        public ShapeSpeed Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public int SpeedX
        {
            get { return _speed.X; }
            set { _speed.X = value; }
        }

        public int SpeedY
        {
            get { return _speed.Y; }
            set { _speed.Y = value; }
        }

        public abstract void Move();
        public abstract void MoveTowards(XY point);
    }
}