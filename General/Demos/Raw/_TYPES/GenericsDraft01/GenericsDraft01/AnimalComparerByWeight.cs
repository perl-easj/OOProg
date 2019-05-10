using System.Collections;
using System.Collections.Generic;

namespace GenericsDraft01
{
    public class AnimalComparerByWeight : IComparer<Animal>
    {
        public int Compare(Animal x, Animal y)
        {
            if (x.Weight < y.Weight)
            {
                return -1;
            }

            if (x.Weight > y.Weight)
            {
                return 1;
            }

            return 0;
        }
    }
}