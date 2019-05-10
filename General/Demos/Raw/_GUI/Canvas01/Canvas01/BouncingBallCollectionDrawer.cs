using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Canvas01
{
    public class BouncingBallCollectionDrawer
    {
        // private int _ballNo = 1;
        private List<BouncingBallRenderer> _ballDrawers;
        private BouncingBallCollection _balls;
        private Canvas _canvas;

        public BouncingBallCollectionDrawer(BouncingBallCollection balls, Canvas canvas)
        {
            _ballDrawers = new List<BouncingBallRenderer>();
            _balls = balls;
            _canvas = canvas;

            CreateDrawers(_balls.Balls);
        }

        public List<BouncingBallRenderer> BallDrawers
        {
            get { return _ballDrawers; }
        }

        public void Add()
        {
            _balls.Increase(1);
        }

        public void Increase(int noOfBalls)
        {
            _balls.Increase(noOfBalls);
            CreateDrawers(GetLast(noOfBalls));
        }

        public void Decrease(int noOfBalls)
        {
            _balls.Decrease(noOfBalls);
            RemoveDrawers(noOfBalls);
        }

        private void CreateDrawers(List<BouncingBall> balls)
        {
            foreach (var ball in balls)
            {
                BouncingBallRenderer bbd = new BouncingBallRenderer(ball, _ballDrawers.Count + 1, _canvas);
                _ballDrawers.Add(bbd);
            }
        }

        private void RemoveDrawers(int noToRemove)
        {
            for (int i = _ballDrawers.Count - noToRemove; i < _ballDrawers.Count; i++)
            {
                _ballDrawers[i].DetachFromCanvas(_canvas);
            }

            _ballDrawers.RemoveRange(_ballDrawers.Count - noToRemove, noToRemove);
        }

        private List<BouncingBall> GetLast(int noOfBalls)
        {
            return _balls.Balls.GetRange(_balls.Balls.Count - noOfBalls, noOfBalls);
        }
    }
}