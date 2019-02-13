using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ASWCClassroomDay2
{
    public class PLINQDemo
    {
        public void Run()
        {
            #region Speed test

            Stopwatch watch = new Stopwatch();

            watch.Restart();
            IEnumerable<int> primes = Enumerable
                .Range(2, 100000)
                .AsParallel()
                .Where(IsPrime);
            int primesCount = primes.Count();
            watch.Stop();

            Console.WriteLine($"Primes up to 1,000,000: {primesCount}");
            Console.WriteLine($"Time spent : {watch.ElapsedMilliseconds} ms");
            Console.WriteLine();

            #endregion


            #region Simple query result processing

            IEnumerable<int> aFewPrimes = Enumerable.Range(2, 100)
                .AsParallel()
                .Where(IsPrime);

            Console.WriteLine("Primes from 2 to 101:");
            foreach (int val in aFewPrimes)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();

            #endregion


            #region Query processing #1 (OK)

            IEnumerable<int> manyPrimes = Enumerable.Range(2, 1000000)
                .AsParallel()
                .Where(IsPrime);

            List<int> primeList = new List<int>();
            foreach (int val in manyPrimes)
            {
                primeList.Add(val);
            }
            Console.WriteLine($"No. of items in primesList : {primeList.Count}");

            #endregion


            #region Query processing #2 (OK)

            primeList.Clear();
            Enumerable.Range(2, 1000000)
                .AsParallel()
                .Where(IsPrime)
                .ToList()
                .ForEach(primeList.Add);
            Console.WriteLine($"No. of items in primesList : {primeList.Count}");

            #endregion


            #region Query processing #3 (ERROR)

            primeList.Clear();
            Enumerable.Range(2, 1000000)
                .AsParallel()
                .Where(IsPrime)
                .ForAll(primeList.Add);
            Console.WriteLine($"No. of items in primesList : {primeList.Count}");

            #endregion


            #region Query processing #4 (OK)

            ConcurrentBag<int> primesBag = new ConcurrentBag<int>();
            Enumerable.Range(2, 1000000)
                .AsParallel()
                .Where(IsPrime)
                .ForAll(primesBag.Add);
            Console.WriteLine($"No. of items in primesBag  : {primesBag.Count}"); 

            #endregion

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