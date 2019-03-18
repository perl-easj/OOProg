using System;

namespace NaiveRPG.Factories
{
    public class RandomUtil
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public static int Percentage()
        {
            return _rng.Next(100);  
        }
    }
}