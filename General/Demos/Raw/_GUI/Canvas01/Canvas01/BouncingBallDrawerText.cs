using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Canvas01.Drawers;

namespace Canvas01
{
    public class BouncingBallDrawerText : ShapeDrawer<BouncingBall, TextBlock>
    {
        private int _ballNo;

        public BouncingBallDrawerText(BouncingBall shape, int ballNo, double canvasTop = 0, double canvasLeft = 0, int zIndex = 1) 
            : base(shape, null, canvasTop, canvasLeft, zIndex)
        {
            _ballNo = ballNo;
        }

        protected override void SetShapeGeometricProperties()
        {
            _uiElement.FontSize = 18;
            _uiElement.FontWeight = FontWeights.Bold;
            _uiElement.Text = _ballNo.ToString();
        }

        protected override void SetShapePropertiesFromPrototype()
        {
        }

        public override void SetAttachedProperties()
        {
            Canvas.SetTop(_uiElement, _canvasTop + _shape.Position.Y - _uiElement.ActualHeight / 2);
            Canvas.SetLeft(_uiElement, _canvasLeft + _shape.Position.X - _uiElement.ActualWidth / 2);
            Canvas.SetZIndex(_uiElement, _zIndex);
        }

        public override void MoveAndDraw()
        {
            _shape.Move();
            SetAttachedProperties();
        }
    }
}