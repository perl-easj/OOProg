using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Canvas01.Drawers;
using Canvas01.Shapes;
using Canvas01.Shapes.Base;

// ReSharper disable ArrangeThisQualifier
// ReSharper disable RedundantExtendsListEntry
// ReSharper disable PossibleLossOfFraction

namespace Canvas01
{
    public class Test
    {
        private static Random _gen = new Random();
        private const int Dimension = 1000;
        private const int LoopCount = 10000;
        private const int DelayMs = 25;

        private int _ballCount;
        private BouncingBallCollectionDrawer _bbcd;
        private object _lock;

        public Test()
        {
            _bbcd = null;
            _ballCount = 100;
            _lock = new object();
        }

        public int BallCount
        {
            get { return _ballCount; }
            set
            {
                lock (_lock)
                {
                    _ballCount = value;

                    if (_bbcd != null)
                    {
                        int currentCount = _bbcd.BallDrawers.Count;
                        int diff = _ballCount - currentCount;
                        if (diff > 0)
                        {
                            _bbcd.Increase(diff);
                        }

                        if (diff < 0)
                        {
                            _bbcd.Decrease(-diff);
                        }
                    } 
                }
            }
        }

        public async void RunTestBalls()
        {
            // Geometry
            int sideLengthY = Dimension;
            int sideLengthX = sideLengthY * 2;
            XY TopLeft = new XY(0, 0);
            XY BottomRight = new XY(sideLengthX, sideLengthY);

            // Polygon prototype (for RectangleShape)
            Polygon pProto = new Polygon
            {
                Stroke = new SolidColorBrush(Colors.DarkGray),
                StrokeThickness = 2
            };

            // Bounding rectangle and associated Drawer
            RectangleShape rA = new RectangleShape(TopLeft, sideLengthX, sideLengthY);
            RectangleDrawer rdA = new RectangleDrawer(rA, pProto);
            rdA.AttachToCanvas(MainCanvas.Instance.TheCanvas);

            BouncingBallCollection bbc = new BouncingBallCollection(new BouncingBallFactory(TopLeft, BottomRight, 20, 80, 1, 5), _ballCount);
            _bbcd = new BouncingBallCollectionDrawer(bbc, MainCanvas.Instance.TheCanvas);

            // Main simulation loop
            for (int i = 1; i <= LoopCount; i++)
            {
                lock (_lock)
                {
                    _bbcd.BallDrawers.ForEach(b => b.MoveAndDraw());
                }
                await Task.Delay(DelayMs);
            }
        }

        public void RunTestTiltRect()
        {
            for (int i = 0; i < 360; i = i + 15)
            {
                DrawTiltedRect(i);
            }
        }

        public void RunTestTiltSquare()
        {
            for (int i = 0; i < 360; i = i + 15)
            {
                DrawTiltedSquare(i);
            }
        }

        public async void RunTestRandomPoints()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                if (i % 100 == 0)
                {
                    await Task.Delay(DelayMs);
                }
                DrawRandomPoint();
            }
        }

        public void RunTestClear()
        {
            MainCanvas.Instance.TheCanvas.Children.Clear();
        }

        private void DrawTiltedSquare(int tilt)
        {
            SquareShape sqA = new SquareShape(new XY(Dimension / 2, Dimension / 2), Dimension / 4, tilt);
            Polygon sqProto = new Polygon();
            sqProto.Stroke = new SolidColorBrush(Colors.Black);
            sqProto.StrokeThickness = 2;
            sqProto.Fill = new SolidColorBrush(Color.FromArgb(255, (byte)((255 * tilt) / 360), 0, 0));

            SquareDrawer sqdA = new SquareDrawer(sqA, sqProto);
            sqdA.AttachToCanvas(MainCanvas.Instance.TheCanvas);
        }

        private void DrawTiltedRect(int tilt)
        {
            RectangleShape rA = new RectangleShape(new XY(Dimension / 2, Dimension / 2), Dimension / 3, Dimension / 5, tilt);
            Polygon pProto = new Polygon
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Color.FromArgb(255, (byte)((255 * tilt) / 360), 0, 0))
            };

            RectangleDrawer rdA = new RectangleDrawer(rA, pProto);
            rdA.AttachToCanvas(MainCanvas.Instance.TheCanvas);
        }

        private void DrawRandomPoint()
        {
            int x = _gen.Next(0, Dimension);
            int y = _gen.Next(0, Dimension);

            Line lp = new Line();
            lp.Stroke = new SolidColorBrush(Inside(x, y) ? Colors.Red : Colors.Black);
            lp.StrokeThickness = 4;

            XY point = new XY(x, y);
            XYDrawer xyd = new XYDrawer(point, lp);
            xyd.AttachToCanvas(MainCanvas.Instance.TheCanvas);
        }

        private bool Inside(double x, double y)
        {
            double xReal = -1 + (x / (Dimension / 2));
            double YReal = 1 - (y / (Dimension / 2));
            return (xReal * xReal + YReal * YReal) < 1.0;
        }
    }
}