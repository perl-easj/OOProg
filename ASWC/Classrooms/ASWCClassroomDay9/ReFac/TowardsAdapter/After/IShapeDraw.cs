using ReFac.TowardsAdapter.Shared;
using ReFac.TowardsAdapter.Shared.Shapes;

namespace ReFac.TowardsAdapter.After
{
    public interface IShapeDraw
    {
        void DrawCircle(Circle obj);
        void DrawRectangle(Rectangle obj);
        void DrawTriangle(Triangle obj);
        void DrawLine(Line obj);
    }
}