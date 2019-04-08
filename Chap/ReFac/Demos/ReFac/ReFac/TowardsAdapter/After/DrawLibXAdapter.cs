using ReFac.TowardsAdapter.Shared;
using ReFac.TowardsAdapter.Shared.Drawing;
using ReFac.TowardsAdapter.Shared.Shapes;

namespace ReFac.TowardsAdapter.After
{
    public class DrawLibXAdapter : IShapeDraw
    {
        private DrawLibX _drawLibX;

        public DrawLibXAdapter()
        {
            _drawLibX = new DrawLibX();
        }

        public void DrawCircle(Circle obj)
        {
            _drawLibX.DrawCircle(obj);
        }

        public void DrawRectangle(Rectangle obj)
        {
            _drawLibX.DrawRectangle(obj);
        }

        public void DrawTriangle(Triangle obj)
        {
            _drawLibX.DrawTriangle(obj);
        }

        public void DrawLine(Line obj)
        {
            _drawLibX.DrawLine(obj);
        }
    }
}