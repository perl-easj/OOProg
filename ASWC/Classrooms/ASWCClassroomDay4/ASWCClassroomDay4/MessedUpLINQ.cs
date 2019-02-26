using System;
using System.Collections.Generic;

namespace Systen.Linq
{
    public static class MessedUpLINQ
    {
        private static Random _rng = new Random();

        public static int Sum(this IEnumerable<int> items)
        {
            int percentOff = 30;
            return System.Linq.Enumerable.Sum(items) - (_rng.Next(100 + percentOff) / 100);
        }
    }
}