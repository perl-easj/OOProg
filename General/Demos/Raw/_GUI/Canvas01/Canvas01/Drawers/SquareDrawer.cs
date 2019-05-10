using Windows.UI.Xaml.Shapes;
using Canvas01.Shapes;

namespace Canvas01.Drawers
{
    public class SquareDrawer : RectangleDrawer
    {
        public SquareDrawer(SquareShape shape, Polygon prototype, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
        }
    }
}