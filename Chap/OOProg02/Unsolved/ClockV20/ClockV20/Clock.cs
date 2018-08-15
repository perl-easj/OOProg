using System;

namespace ClockV20
{
    /// <summary>
    /// This class simulates a simple 24-hour clock,
    /// showing hours, minutes and seconds, prefixed by
    /// a user-defined text.
    /// </summary>
    public class Clock
    {
        #region Instance fields
        private int _secondsSinceMidnight;
        private int _tickFactor;
        private string _text;
        private int _verticalPosition;

        // Included to enable neat printing of several clocks.
        private static int _noOfClocksCreated;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new Clock object
        /// </summary>
        /// <param name="text">
        /// User-defined prefix text, e.g. "The time is now "
        /// </param>
        /// <param name="tickFactor">
        /// If you want to advance the clock by several seconds for
        /// each tick, set tickFactor to the desired number of seconds.
        /// </param>
        public Clock(string text, int tickFactor = 1)
        {
            _text = text;
            _tickFactor = tickFactor;
            _secondsSinceMidnight = 0;
            _verticalPosition = _noOfClocksCreated;

            _noOfClocksCreated++;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Advances the clock by _tickFactor seconds.
        /// </summary>
        public void Tick()
        {
            _secondsSinceMidnight += _tickFactor;
        }

        /// <summary>
        /// Print the time. Note that the time is always 
        /// printed at the same position on the screen.
        /// </summary>
        public void PrintTime()
        {
            Console.SetCursorPosition(0, _verticalPosition);
            Console.WriteLine(this);
        }

        /// <summary>
        /// String conversion, breaking the elapsed number of seconds
        /// into hours, minutes and sesconds.
        /// </summary>
        public override string ToString()
        {
            int hours = _secondsSinceMidnight / 3600;
            int minutes = (_secondsSinceMidnight - 3600 * hours) / 60;
            int seconds = (_secondsSinceMidnight - 3600 * hours - 60 * minutes);
            return $"{_text} {hours:00}:{minutes:00}:{seconds:00}";
        } 
        #endregion
    }
}