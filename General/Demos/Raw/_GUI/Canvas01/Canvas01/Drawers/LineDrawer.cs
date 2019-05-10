using Windows.UI.Xaml.Shapes;
using Canvas01.Shapes;

namespace Canvas01.Drawers
{
    public class LineDrawer : ShapeDrawer<LineShape, Line>
    {
        public LineDrawer(LineShape shape, Line prototype, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.X1 = _shape.From.X;
            _uiElement.Y1 = _shape.From.Y;
            _uiElement.X2 = _shape.To.X;
            _uiElement.Y2 = _shape.To.Y;
        }

        protected override void SetShapePropertiesFromPrototype()
        {
            _uiElement.Stroke = _prototype.Stroke;
            _uiElement.StrokeThickness = _prototype.StrokeThickness;
        }
    }
}