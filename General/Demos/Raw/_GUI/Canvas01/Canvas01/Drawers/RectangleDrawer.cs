using System;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Canvas01.Shapes;

namespace Canvas01.Drawers
{
    public class RectangleDrawer : ShapeDrawer<RectangleShape, Polygon>
    {
        public RectangleDrawer(RectangleShape shape, Polygon prototype, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.Points = new PointCollection();
            double tiltInRad = (2.0 * Math.PI * _shape.Tilt) / 360.0;
            double sinAdjX = _shape.SideLengthX * Math.Sin(tiltInRad);
            double cosAdjX = _shape.SideLengthX * Math.Cos(tiltInRad);
            double sinAdjY = _shape.SideLengthY * Math.Sin(tiltInRad);
            double cosAdjY = _shape.SideLengthY * Math.Cos(tiltInRad);

            double x1 = _shape.TopLeft.X;
            double y1 = _shape.TopLeft.Y;
            double x2 = x1 + cosAdjX;
            double y2 = y1 + sinAdjX;
            double x3 = x2 - sinAdjY;
            double y3 = y2 + cosAdjY;
            double x4 = x3 - cosAdjX;
            double y4 = y3 - sinAdjX;

            _uiElement.Points.Add(new Point(x1, y1));
            _uiElement.Points.Add(new Point(x2, y2));
            _uiElement.Points.Add(new Point(x3, y3));
            _uiElement.Points.Add(new Point(x4, y4));
        }

        protected override void SetShapePropertiesFromPrototype()
        {
            _uiElement.Fill = _prototype.Fill;
            _uiElement.Stroke = _prototype.Stroke;
            _uiElement.StrokeThickness = _prototype.StrokeThickness;
        }
    }
}