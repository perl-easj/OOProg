using CompositeShapes.Interfaces;

namespace CompositeShapes.Shapes
{
    public class Line : IShape
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public void Move(double dx, double dy)
        {
            Start.Move(dx, dy);
            End.Move(dx, dy);
        }

        public void Resize(double factor)
        {
            Start = new Point(Start.X * factor, Start.Y * factor);
            End = new Point(End.X * factor, End.Y * factor);
        }

        public Point Center
        {
            get
            {
                double cx = (Start.X + End.X) / 2;
                double cy = (Start.Y + End.Y) / 2;
                return new Point(cx, cy);
            }
        }

        public override string ToString()
        {
            return $"A Line from {Start.ToCoord()} to {End.ToCoord()}";
        }
    }
}