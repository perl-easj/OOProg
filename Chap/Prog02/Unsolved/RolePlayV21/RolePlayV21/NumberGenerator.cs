using System;

namespace RolePlayV21
{
    /// <summary>
    /// This class is for generation of random numbers within a given interval
    /// </summary>
    public class NumberGenerator
    {
        private Random _generator;

        public NumberGenerator()
        {
            _generator = new Random();
        }

        /// <summary>
        /// Returns a random number in the interval between the values of 
        /// "min" and "max"
        /// </summary>
        public int Next(int min, int max)
        {
            int value = min + _generator.Next(max - min + 1);
            return value;
        }
    }
}