
using System.Collections.Generic;
using System.Linq;

namespace ObservableInt
{
    public static class PSL_ObsIntExt
    {
        public static int Smallest(this IEnumerable<PSL_ObsInt> collection)
        {
            return collection.Min(i => i.Value);
        }

        public static int Total(this IEnumerable<PSL_ObsInt> collection)
        {
            return collection.Sum(i => i.Value);
        }

        // TODO - implement ObsIntExt
    }
}