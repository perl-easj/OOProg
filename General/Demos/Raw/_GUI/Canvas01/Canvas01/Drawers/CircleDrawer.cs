using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Canvas01.Shapes;
using Canvas01.Shapes.Circles;

namespace Canvas01.Drawers
{
    public class CircleDrawer : ShapeDrawer<CircleBase, Ellipse>
    {
        public CircleDrawer(CircleBase shape, Ellipse prototype, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.Width = _shape.Radius * 2;
            _uiElement.Height = _shape.Radius * 2;
        }

        protected override void SetShapePropertiesFromPrototype()
        {
            _uiElement.Fill = _prototype.Fill;
            _uiElement.Stroke = _prototype.Stroke;
            _uiElement.StrokeThickness = _prototype.StrokeThickness;
        }

        public override void SetAttachedProperties()
        {
            Canvas.SetTop(_uiElement, _canvasTop + _shape.Center.Y - _shape.Radius);
            Canvas.SetLeft(_uiElement, _canvasLeft + _shape.Center.X - _shape.Radius);
            Canvas.SetZIndex(_uiElement, _zIndex);
        }
    }
}