using System;
using System.Collections.Generic;

namespace GenericsDraft01
{
    public class CircleCompareByX : IComparer<Circle>
    {
        public int Compare(Circle c1, Circle c2)
        {
            if (c1 == null || c2 == null)
            {
                throw new ArgumentException();
            }

            if (c1.X > c2.X)
            {
                return 1;
            }

            if (c1.X < c2.X)
            {
                return -1;
            }

            return 0;
        }
    }
}