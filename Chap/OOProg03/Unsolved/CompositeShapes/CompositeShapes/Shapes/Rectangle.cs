using CompositeShapes.Interfaces;

namespace CompositeShapes.Shapes
{
    public class Rectangle : IShape
    {
        public Point TopLeft { get; private set; }
        public Point BotRight { get; private set; }

        public Rectangle(Point topLeft, Point botRight)
        {
            TopLeft = topLeft;
            BotRight = botRight;
        }

        public void Move(double dx, double dy)
        {
            TopLeft.Move(dx, dy);
            BotRight.Move(dx, dy);
        }

        public void Resize(double factor)
        {
            TopLeft = new Point(TopLeft.X * factor, TopLeft.Y * factor);
            BotRight = new Point(BotRight.X * factor, BotRight.Y * factor);
        }

        public Point Center
        {
            get
            {
                double cx = (TopLeft.X + BotRight.X) / 2;
                double cy = (TopLeft.Y + BotRight.Y) / 2;
                return new Point(cx, cy);
            }
        }

        public override string ToString()
        {
            return $"A Rectangle from {TopLeft.ToCoord()} to {BotRight.ToCoord()}";
        }
    }
}