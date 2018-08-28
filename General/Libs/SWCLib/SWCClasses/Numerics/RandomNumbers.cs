using System;

namespace SWCClasses.Numerics
{
    public class RandomNumbers
    {
        private static Random _random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Generates a random double value between 0.0 and 1.0.
        /// </summary>
        public static double GenerateBetween0and1()
        {
            return _random.NextDouble();
        }

        /// <summary>
        /// Generates a random integer value between
        /// minimum and maximum, both included.
        /// </summary>
        public static int Generate(int minimum, int maximum)
        {
            return _random.Next(minimum, maximum + 1);
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
            int generatedPercentage = Generate(0, 100);
            return generatedPercentage < percentage;
        }
    }
}