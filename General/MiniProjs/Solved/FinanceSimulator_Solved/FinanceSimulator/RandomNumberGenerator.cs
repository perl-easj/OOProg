using System;

namespace FinanceSimulator
{
    /// <summary>
    /// Helper class for generating numbers (int or double)
    /// within a specified interval.
    /// </summary>
    public class RandomNumberGenerator
    {
        private static Random _generator = new Random();

        #region Methods
        /// <summary>
        /// Returns a random double value within the specified interval.
        /// </summary>
        /// <param name="minValue">Lowest possible value</param>
        /// <param name="maxValue">Highest possible value</param>
        /// <returns>Random value within interval</returns>
        public static double Next(double minValue, double maxValue)
        {
            double randomNumber = _generator.NextDouble();
            return minValue + (maxValue - minValue) * randomNumber;
        }

        /// <summary>
        /// Returns a random integer value within the specified interval.
        /// </summary>
        /// <param name="minValue">Lowest possible value</param>
        /// <param name="maxValue">Highest possible value</param>
        /// <returns>Random value within interval</returns>
        public static int NextInt(int minValue, int maxValue)
        {
            return _generator.Next(minValue, maxValue + 1);
        } 
        #endregion
    }
}