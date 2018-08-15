using System;

namespace RolePlayV23
{
    /// <summary>
    /// This class is for generation of random numbers within a given interval
    /// </summary>
    public static class NumberGenerator
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

        /// <summary>
        /// Generates a random percentage number (betweeen 0 and 100),
        /// and returns whether or not this number is smaller than the
        /// specified percentage. The call BelowPercentage(40) will
        /// thus return true in 40 % of all calls, and return false in
        /// 60 % of all calls.
        /// </summary>
        public static bool BelowPercentage(int percentage)
        {
            int generatedPercentage = Next(0, 100);
            return generatedPercentage < percentage;
        }
    }
}
