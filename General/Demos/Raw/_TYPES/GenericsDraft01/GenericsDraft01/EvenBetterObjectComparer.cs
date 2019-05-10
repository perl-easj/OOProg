using System.Collections.Generic;

namespace GenericsDraft01
{
    public class EvenBetterObjectComparer
    {
        public T Largest<T>(T a, T b, T c, IComparer<T> comparer)
        {
            if (comparer.Compare(a, b) > 0)
            {
                return (comparer.Compare(a, c) > 0) ? a : c;
            }

            return (comparer.Compare(b, c) > 0) ? b : c;
        }
    }
}