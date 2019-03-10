using System;

namespace WildLife.Common
{
    public class Randomizer
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public static bool CoinFlip(int sides = 2)
        {
            return _rng.Next(sides) == 0;
        }
    }
}