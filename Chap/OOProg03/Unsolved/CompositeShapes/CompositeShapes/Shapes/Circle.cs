using CompositeShapes.Interfaces;

namespace CompositeShapes.Shapes
{
    public class Circle : IShape
    {
        public Point Center { get; private set; }
        public double Radius { get; private set; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public void Move(double dx, double dy)
        {
            Center.Move(dx, dy);
        }

        public void Resize(double factor)
        {
            Radius = Radius * factor;
        }

        public override string ToString()
        {
            return $"A Circle at {Center.ToCoord()}, radius = {Radius}";
        }
    }
}