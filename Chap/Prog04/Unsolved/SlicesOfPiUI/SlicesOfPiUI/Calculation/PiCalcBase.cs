using System;

namespace SlicesOfPiUI.Calculation
{
    /// <summary>
    /// This class contains the general algorithm for
    /// calculation of an approximate value of pi.
    /// </summary>
    public class PiCalcBase
    {
        #region Instance fields
        private IProgress<long> _progress;
        private Random _generator;
        protected long _iterations;
        protected long _insideUnitCircle;
        #endregion

        #region Constructor
        public PiCalcBase(IProgress<long> progressCallback)
        {
            _progress = progressCallback;
            _generator = new Random(Guid.NewGuid().GetHashCode());
            _iterations = 0;
            _insideUnitCircle = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Contains the main algorithm. Note that the algorithm
        /// is parameterised with a continuation condition.
        /// </summary>
        protected void Calculate(PiCalcData data, Func<bool> continueCondition)
        {
            _iterations = 0;
            _insideUnitCircle = 0;

            while (continueCondition())
            {
                _iterations++;
                _insideUnitCircle += RandomPointWithinUnitCircle();
                UpdateDataObject(data);
            }
        }

        /// <summary>
        /// Update the data object at regular intervals.
        /// </summary>
        private void UpdateDataObject(PiCalcData data)
        {
            if (_iterations % 1000000 == 0)
            {
                data.Pi = _insideUnitCircle * 4.0 / _iterations;
                data.Iterations = _iterations;

                _progress.Report(_iterations);
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
        #endregion
    }
}