using System;
using System.Collections;
using System.Collections.Generic;

namespace ASWCClassroomDay3
{
    /// <summary>
    /// Class which "contains" all primes from 2 to the given limit.
    /// Note that GetEnumerator() is implemented by calculation.
    /// </summary>
    public class PrimesContainer : IEnumerable<int>
    {
        private readonly int _limit;

        public PrimesContainer(int limit)
        {
            _limit = limit;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 2; i < _limit; i++)
            {
                if (IsPrime(i))
                {
                    yield return i;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsPrime(int number)
        {
            int limit = Convert.ToInt32(Math.Sqrt(number));
            bool isPrime = true;

            for (int i = 2; i <= limit && isPrime; i++)
            {
                isPrime = number % i != 0;
            }

            return isPrime;
        }
    }
}