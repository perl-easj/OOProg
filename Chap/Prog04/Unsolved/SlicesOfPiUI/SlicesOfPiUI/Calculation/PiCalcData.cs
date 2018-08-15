namespace SlicesOfPiUI.Calculation
{
    /// <summary>
    /// This class holds data that the calculator 
    /// and the UI need to share.
    /// </summary>
    public class PiCalcData
    {
        #region Instance fields
        private double _pi;
        private long _iterations;
        #endregion

        #region Constructor
        public PiCalcData()
        {
            _pi = 0.0;
            _iterations = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Holds the currently calculated value of pi. 
        /// </summary>
        public double Pi
        {
            get { return _pi; }
            set { _pi = value; }
        }

        /// <summary>
        /// Holds the total number of iterations performed
        /// so far during the calculation.
        /// </summary>
        public long Iterations
        {
            get { return _iterations; }
            set { _iterations = value; }
        }
        #endregion
    }
}