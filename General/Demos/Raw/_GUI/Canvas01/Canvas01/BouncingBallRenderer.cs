using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Canvas01.Drawers;

namespace Canvas01
{
    public class BouncingBallRenderer
    {
        private List<IShapeDrawer<UIElement>> _drawers;

        public BouncingBallRenderer(BouncingBall ball, int ballNo, Canvas theCanvas)
        {
            _drawers = new List<IShapeDrawer<UIElement>>();

            Ellipse ellipProto = new Ellipse
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.Green)
            };

            _drawers.Add(new BouncingBallDrawer(ball, ellipProto, true, 0, 0, ballNo * 2));
            _drawers.Add(new BouncingBallDrawerText(ball, ballNo, 0, 0, ballNo * 2 + 1));

            AttachToCanvas(theCanvas);
        }

        public void AttachToCanvas(Canvas theCanvas)
        {
            foreach (var shapeDrawer in _drawers)
            {
                shapeDrawer.AttachToCanvas(theCanvas);
            }
        }

        public void DetachFromCanvas(Canvas theCanvas)
        {
            foreach (var shapeDrawer in _drawers)
            {
                shapeDrawer.DetachFromCanvas(theCanvas);
            }
        }

        public void SetAttachedProperties()
        {
            foreach (var shapeDrawer in _drawers)
            {
                shapeDrawer.SetAttachedProperties();
            }
        }

        public void MoveAndDraw()
        {
            foreach (var shapeDrawer in _drawers)
            {
                shapeDrawer.MoveAndDraw();
            }
        }
    }
}
