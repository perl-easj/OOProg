using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Canvas01.Shapes;
using Canvas01.Shapes.Base;

namespace Canvas01.Drawers
{
    public class XYDrawer : ShapeDrawer<XY, Line>
    {
        public XYDrawer(XY shape, Line prototype, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.X1 = _shape.X;
            _uiElement.Y1 = _shape.Y;
            _uiElement.X2 = _shape.X;
            _uiElement.Y2 = _shape.Y;
        }

        protected override void SetShapePropertiesFromPrototype()
        {
            _uiElement.Stroke = _prototype.Stroke;
            _uiElement.StrokeThickness = _prototype.StrokeThickness;
            _uiElement.StrokeStartLineCap = PenLineCap.Square;
        }
    }
}