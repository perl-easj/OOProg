using System;

namespace PrimesSieve
{
    public class Tester
    {
        public void Run()
        {
            // You can check results against e.g.
            // https://primes.utm.edu/howmany.html
            //
            RunSingleTest(1000);
            RunSingleTest(10000);
            RunSingleTest(100000);
            RunSingleTest(1000000);
        }

        private void RunSingleTest(int n)
        {
            int noOfPrimes = PrimesCalculator.NoOfPrimesUpToN(n);
            Console.WriteLine($"Number of primes up to {n}: {noOfPrimes}");
        }
    }
}