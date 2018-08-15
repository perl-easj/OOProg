using System;

namespace GenericsDogsAndCircles
{
    public class BetterObjectComparer<T> where T : IComparable<T>
    {
        public T Largest(T a, T b, T c)
        {
            if (a.CompareTo(b) > 0)
            {
                return (a.CompareTo(c) > 0) ? a : c;
            }

            return (b.CompareTo(c) > 0) ? b : c;
        }
    }
}