using System;

namespace PvPSimulator.Utility
{
    /// <summary>
    /// Class for generating random numbers
    /// within specified intervals.
    /// The class is a Singleton.
    /// </summary>
    public class NumberGenerator
    {
        #region Instance fields
        private Random _generator;
        #endregion

        #region Singleton implementation
        private static NumberGenerator _instance;
        public static NumberGenerator Instance
        {
            get
            {
                _instance = _instance ?? new NumberGenerator();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private NumberGenerator()
        {
            _generator = new Random();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a random integer number in the interval 
        /// between the values of "min" and "max"
        /// </summary>
        public int Next(int min, int max)
        {
            int value = min + _generator.Next(max - min + 1);
            return value;
        }

        /// <summary>
        /// Returns a random double number in the interval 
        /// between the values of "min" and "max"
        /// </summary>
        public double Next(double min, double max)
        {
            double value = min + (_generator.NextDouble() * (max - min));
            return value;
        } 
        #endregion
    }
}