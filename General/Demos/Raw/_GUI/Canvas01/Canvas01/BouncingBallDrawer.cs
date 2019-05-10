using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Canvas01.Drawers;

namespace Canvas01
{
    public class BouncingBallDrawer : ShapeDrawer<BouncingBall, Ellipse>
    {
        private static Random _gen = new Random();
        private bool _randomColor;

        public BouncingBallDrawer(BouncingBall shape, Shape prototype, bool randomColor = false, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, prototype, canvasTop, canvasLeft, zIndex)
        {
            _randomColor = randomColor;
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.Width = _shape.Radius * 2;
            _uiElement.Height = _shape.Radius * 2;
        }

        protected override void SetShapePropertiesFromPrototype()
        {
            _uiElement.Fill = _randomColor ? GenerateColor() : _prototype.Fill;
            _uiElement.Stroke = _prototype.Stroke;
            _uiElement.StrokeThickness = _prototype.StrokeThickness;
        }

        public override void SetAttachedProperties()
        {
            Canvas.SetTop(_uiElement, _canvasTop + _shape.Position.Y - _shape.Radius);
            Canvas.SetLeft(_uiElement, _canvasLeft + _shape.Position.X - _shape.Radius);
            Canvas.SetZIndex(_uiElement, _zIndex);
        }

        public override void MoveAndDraw()
        {
            _shape.Move();
            SetAttachedProperties();
        }

        private SolidColorBrush GenerateColor()
        {
            byte r = (byte)_gen.Next(0, 256);
            byte g = (byte)_gen.Next(0, 256);
            byte b = (byte)_gen.Next(0, 256);

            return new SolidColorBrush(Color.FromArgb(255, r, g, b));
        }
    }
}