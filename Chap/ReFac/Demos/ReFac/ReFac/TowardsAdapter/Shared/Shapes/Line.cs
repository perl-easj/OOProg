using ReFac.TowardsAdapter.Shared.Interfaces;

namespace ReFac.TowardsAdapter.Shared.Shapes
{
    public class Line : IShape
    {
        public Point TopLeft { get; }
        public Point BotRight { get; }

        public Line(Point topLeft, Point botRight)
        {
            TopLeft = topLeft;
            BotRight = botRight;
        }
    }
}