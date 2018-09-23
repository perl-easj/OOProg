using System;

namespace SlicesOfPiUI.Calculation
{
    /// <summary>
    /// This class contains the general algorithm for
    /// calculation of an approximate value of pi.
    /// </summary>
    public abstract class PiCalcBase
    {
        #region Instance fields
        private IProgress<long> _progress;
        private Random _generator;
        protected long _iterationsDone;
        protected long _iterationsRequested;
        protected long _insideUnitCircle;
        #endregion

        #region Constructor

        protected PiCalcBase(IProgress<long> progressCallback)
        {
            _progress = progressCallback;
            _generator = new Random(Guid.NewGuid().GetHashCode());
            _iterationsRequested = 0;
            _iterationsDone = 0;
            _insideUnitCircle = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Contains the main algorithm. Note that the algorithm
        /// uses the (abstract) method StopCondition.
        /// </summary>
        protected double Calculate()
        {
            _iterationsDone = 0;
            _insideUnitCircle = 0;

            while (!StopCondition())
            {
                _iterationsDone++;
                _insideUnitCircle += RandomPointWithinUnitCircle();
                ReportProgress();
            }

            return (_insideUnitCircle * 4.0) / _iterationsDone;
        }

        /// <summary>
        /// Report progress at regular intervals.
        /// </summary>
        private void ReportProgress()
        {
            if (_iterationsDone % 1000000 == 0)
            {
                _progress.Report(_iterationsDone);
            }
        }

        /// <summary>
        /// Generates a random point within the unit square,
        /// and returns whether or not the point was within
        /// the unit circle (0 for no, 1 for yes)
        /// </summary>
        private int RandomPointWithinUnitCircle()
        {
            // Create random point inside the unit square
            double x = _generator.NextDouble();
            double y = _generator.NextDouble();

            return (x * x + y * y < 1.0) ? 1 : 0;
        }

        /// <summary>
        /// A derived class must override this method
        /// </summary>
        protected abstract bool StopCondition();
        #endregion
    }
}