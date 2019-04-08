using ReFac.TowardsAdapter.Shared.Interfaces;

namespace ReFac.TowardsAdapter.Shared.Shapes
{
    public class Rectangle : IShape
    {
        public Point TopLeft { get; }
        public Point BotRight { get; }

        public Rectangle(Point topLeft, Point botRight)
        {
            TopLeft = topLeft;
            BotRight = botRight;
        }
    }
}