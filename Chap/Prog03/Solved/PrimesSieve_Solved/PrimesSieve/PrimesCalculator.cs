using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimesSieve
{
    /// <summary>
    /// This class contains a algorithm for calculating all prime numbers up  
    /// to a given limit. The algorithm is based on the Sieve of Eratosthenes,
    /// https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes, where you iteratively
    /// remove numbers from a list of candidate numbers.
    /// </summary>
    public class PrimesCalculator
    {
        #region Public methods
        public static int NoOfPrimesUpToN(int n)
        {
            // Two lists are maintained:
            // 1) A list of candidate primes, i.e. numbers which MAY be primes.
            //    This list is initialised to: [ 2, 3, 4, 5, 6, 7,...,n ]
            // 2) A list of confirmed primes, i.e. numbers which are PROVEN to be primes.
            //    This list is initialised to being empty.
            List<int> candidatePrimes = GenerateRange(2, 1, n);
            List<int> confirmedPrimes = new List<int>();

            // Keep going as long as the Stop criterion is not met.
            while (!StopCondition(n, confirmedPrimes))
            {
                // STEP 1:
                // Pick out the first number from the candidate primes.
                // This number is now guaranteed to be a prime.
                int nextPrime = candidatePrimes.First();
                confirmedPrimes.Add(nextPrime);

                // STEP 2:
                // Generate a list of "prime multiples", i.e. multiples of the prime
                // (i.e. nextPrime) we have just found. If the prime we found was e.g. 7,
                // the list of multiples would be [7, 14, 21, 28, 35, ...] up to n.
                IEnumerable<int> primeMultiples = GenerateRange(nextPrime, nextPrime, n);

                // STEP 3:
                // Use the list of prime multiples to eliminate non-primes from the
                // list of candidate primes.
                candidatePrimes = candidatePrimes.Except(primeMultiples).ToList();
            }

            // At this point, it will hold that:
            // 1) All numbers in confirmedPrimes are prime numbers
            // 2) All remaining numbers in candidatePrimes are also prime numbers
            // 3) No number will be in both lists.

            // Update confirmedPrimes such that it contains ALL primes.
            confirmedPrimes = confirmedPrimes.Union(candidatePrimes).ToList();

            // Return the count of confirmed primes.
            return confirmedPrimes.Count;
        } 
        #endregion

        #region Helper methods
        /// <summary>
        /// This is an important helper method, which can generate a sequence of numbers
        /// governed by the input arguments. You do NOT need to change this code.
        /// Example: Calling the methods with (3, 5 , 1000) wil return the sequence
        ///          [3, 8, 13, 18, 23, 28, ..., 998]
        /// </summary>
        /// <param name="start">First number on the generated sequence</param>
        /// <param name="step">Step between generated numbers</param>
        /// <param name="max">Upper limit on last number in sequence</param>
        private static List<int> GenerateRange(int start, int step, int max)
        {
            return Enumerable.Range(start, max) // Generates the "full" list from start to max: [start, start+1, start+2, ..., max]
                .Where(n => (n - start) % step == 0) // Filter out values compatible with the "step" value
                .ToList();
        }

        /// <summary>
        /// This method defines the stop criterion for the algorithm.
        /// You do NOT need to change this code.
        /// </summary>
        /// <param name="maxNumber">Upper limit for prime numbers</param>
        /// <param name="confirmedPrimes">List of already confirmed primes</param>
        /// <returns></returns>
        private static bool StopCondition(int maxNumber, List<int> confirmedPrimes)
        {
            if (confirmedPrimes == null)
            {
                throw new ArgumentException("PrimesCalculator:StopCondition called with confirmedPrimes set to null");
            }

            return (confirmedPrimes.Count > 0) && ((confirmedPrimes.Last() * confirmedPrimes.Last()) > maxNumber);
        } 
        #endregion
    }
}