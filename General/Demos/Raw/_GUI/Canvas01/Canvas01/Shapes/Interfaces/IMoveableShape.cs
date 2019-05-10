using Canvas01.Shapes.Base;

namespace Canvas01.Shapes.Interfaces
{
    public interface IMoveableShape
    {
        ShapeSpeed Speed { get; set; }
        int SpeedX { get; set; }
        int SpeedY { get; set; }
        void Move();
        void MoveTowards(XY point);
    }
}