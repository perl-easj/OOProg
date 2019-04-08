using ReFac.TowardsAdapter.Shared;
using ReFac.TowardsAdapter.Shared.Drawing;
using ReFac.TowardsAdapter.Shared.Shapes;

namespace ReFac.TowardsAdapter.After
{
    public class DrawLibYAdapter : IShapeDraw
    {
        private DrawLibY _drawLibY;

        public DrawLibYAdapter()
        {
            _drawLibY = new DrawLibY();
        }

        public void DrawCircle(Circle obj)
        {
            _drawLibY.DrawCircle(obj.Center.X, obj.Center.Y, obj.Radius);
        }

        public void DrawRectangle(Rectangle obj)
        {
            _drawLibY.DrawLine(obj.TopLeft.X, obj.TopLeft.Y, obj.BotRight.X, obj.TopLeft.Y);
            _drawLibY.DrawLine(obj.BotRight.X, obj.TopLeft.Y, obj.BotRight.X, obj.BotRight.Y);
            _drawLibY.DrawLine(obj.BotRight.X, obj.BotRight.Y, obj.TopLeft.X, obj.BotRight.Y);
            _drawLibY.DrawLine(obj.TopLeft.X, obj.BotRight.Y, obj.TopLeft.X, obj.TopLeft.Y);
        }

        public void DrawTriangle(Triangle obj)
        {
            _drawLibY.DrawLine(obj.A.X, obj.A.Y, obj.B.X, obj.B.Y);
            _drawLibY.DrawLine(obj.B.X, obj.B.Y, obj.C.X, obj.C.Y);
            _drawLibY.DrawLine(obj.C.X, obj.C.Y, obj.A.X, obj.A.Y);
        }

        public void DrawLine(Line obj)
        {
            _drawLibY.DrawLine(obj.TopLeft.X, obj.TopLeft.Y, obj.BotRight.X, obj.BotRight.Y);
        }
    }
}