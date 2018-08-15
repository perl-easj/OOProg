using System;

namespace DiceGame
{
    public class RandomNumberGenerator
    {
        private static Random _random = new Random();

        public static int Generate(int minimum, int maximum)
        {
            return _random.Next(minimum, maximum + 1);
        }
    }
}