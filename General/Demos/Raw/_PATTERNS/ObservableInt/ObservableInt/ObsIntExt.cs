using System;
using System.Collections.Generic;
using System.Linq;

namespace ObservableInt
{
    public static class ObsIntExt
    {
        public static int Total(this IEnumerable<ObsInt> obsIntColl)
        {
            return obsIntColl.Select(o => o.Value).Sum();
        }

        public static int Smallest(this IEnumerable<ObsInt> obsIntColl)
        {
            List<ObsInt> obsIntList = obsIntColl.ToList();
            if (!obsIntList.Any())
            {
                throw new ArgumentException("Call of Smallest with zero-length collection");
            }

            return obsIntList.Select(o => o.Value).Min();
        }
    }
}