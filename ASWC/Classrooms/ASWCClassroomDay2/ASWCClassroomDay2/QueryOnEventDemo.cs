using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ASWCClassroomDay2
{
    public class QueryOnEventDemo
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        private event Action NumberAdded;

        public QueryOnEventDemo()
        {
            Numbers = new List<int>();
            NumberAdded += Do;
        }

        public async Task Run()
        {
            while (true)
            {
                await Task.Delay(200);
                AddNumber();
            }
        }

        private List<int> Numbers { get; }

        public void AddNumber()
        {
            Numbers.Add(_rng.Next(1000000));
            OnNumberAdded();
        }

        public void Do()
        {
            Console.Clear();
            Console.WriteLine($"---- Primes in collection ---- ({Numbers.Count} numbers)");
            IEnumerable<int> primeNumbers = Numbers.Where(IsPrime);
            foreach (int prime in primeNumbers)
            {
                Console.WriteLine(prime);
            }
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

        protected virtual void OnNumberAdded()
        {
            NumberAdded?.Invoke();
        }
    }
}