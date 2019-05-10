namespace MultiProg01
{
    public class CalcResult
    {
        private double _pi;
        private bool _quit;
        private long _iterations;

        public CalcResult()
        {
            _pi = 0.0;
            _quit = false;
            _iterations = 0;
        }

        public double Pi
        {
            get { return _pi; }
            set { _pi = value; }
        }

        public bool Quit
        {
            get { return _quit; }
            set { _quit = value; }
        }

        public long Iterations
        {
            get { return _iterations; }
            set { _iterations = value; }
        }
    }
}