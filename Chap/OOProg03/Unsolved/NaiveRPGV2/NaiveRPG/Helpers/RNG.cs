using System;
using System.Runtime.InteropServices;

namespace NaiveRPG.Helpers
{
    /// <summary>
    /// Class for generation of random numbers
    /// </summary>
    public static class RNG
    {
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());

        public static int RandomInt(int minVal, int maxVal)
        {
            return _generator.Next(minVal, maxVal + 1);
        }

        public static int RandomPercent()
        {
            return _generator.Next(0, 100);
        }

        public static double RandomDouble(double minVal, double maxVal)
        {
            return _generator.NextDouble()*(maxVal - minVal) + minVal;
        }

        public static bool CoinFlip()
        {
            return RandomPercent() < 50;
        }
    }
}