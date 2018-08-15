using System;

namespace WesternStrike.Combat
{
    public class NumberGenerator
    {
        private static Random _generator = new Random();

        /// <summary>
        /// Returns a random number in the interval between the values of 
        /// "min" and "max"
        /// </summary>
        public static int Next(int min, int max)
        {
            int value = min + _generator.Next(max - min);
            return value;
        }
    }
}