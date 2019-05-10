using System.Collections.Generic;

namespace Canvas01
{
    public class BouncingBallCollection
    {
        private List<BouncingBall> _balls;
        private BouncingBallFactory _factory;

        public BouncingBallCollection(BouncingBallFactory factory, int noOfBalls = 0)
        {
            _factory = factory;
            _balls = new List<BouncingBall>();
            Increase(noOfBalls);
        }

        public List<BouncingBall> Balls
        {
            get { return _balls; }
        }

        public void Add(BouncingBall ball)
        {
            _balls.Add(ball);
        }

        public void Increase(int noOfBalls)
        {
            for (int i = 0; i < noOfBalls; i++)
            {
                _balls.Add(Generate());
            }
        }

        public void Decrease(int noOfBalls)
        {
            for (int i = 0; i < noOfBalls; i++)
            {
                _balls.RemoveAt(_balls.Count - 1);
            }
        }

        private BouncingBall Generate()
        {
            return _factory.Create();
        }
    }
}