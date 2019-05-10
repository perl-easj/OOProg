using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Canvas01.Shapes;
using Canvas01.Shapes.Base;

namespace Canvas01.Drawers
{
    public class PolyLineDrawer : ShapeDrawer<PolyLineShape, Polyline>
    {
        public PolyLineDrawer(PolyLineShape shape, Polyline prototype, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.Points = new PointCollection();
            foreach (XY p in _shape.Points)
            {
                _uiElement.Points.Add(new Point(p.X, p.Y));
            }
        }

        protected override void SetShapePropertiesFromPrototype()
        {
            _uiElement.Stroke = _prototype.Stroke;
            _uiElement.StrokeThickness = _prototype.StrokeThickness;
        }
    }
}