using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiProg01
{
    public class PrimeCalc
    {
        private ConcurrentBag<int> _primes;

        public PrimeCalc()
        {
            _primes = new ConcurrentBag<int>();    
        }

        public void FindPrimes(int upper)
        {
            FindPrimesInInterval(2, upper);
            string text = $"Found {_primes.Count} primes in [2; {upper}]";
            Console.WriteLine(text);
        }


        private void FindPrimesInInterval(int lower, int upper)
        {
            Parallel.For(lower, upper, (i) =>
            {
                if (IsPrime(i))
                {
                    _primes.Add(i);
                }
            });
        }

        private bool IsPrime(int number)
        {
            if (number < 4) { return true; }

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