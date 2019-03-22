using System;
using System.Collections.Generic;
using System.Linq;

namespace NaiveRPG.Factories
{
    public class RandomizedFactory<T> : IFactory<T>
    {
        // Each Tuple contains a (percentage, factory) pair
        // The percentage defines the probability for using
        // the corresponding factory.
        private List<Tuple<int, Func<T>>> _factories;

        public RandomizedFactory()
        {
            _factories = new List<Tuple<int, Func<T>>>();
        }

        public void AddFactoryMethod(int prob, Func<T> fac)
        {
            _factories.Add(new Tuple<int, Func<T>>(prob, fac));
        }

        /// <summary>
        /// Checks that the available factories have percentages
        /// summing up to exactly 100.
        /// </summary>
        private bool ConsistencyCheck()
        {
            return _factories.Select(e => e.Item1).Sum() == 100;
        }

        public T Create()
        {
            if (ConsistencyCheck())
            {
                int index = PercentageToIndex(RandomUtil.Percentage());
                return _factories[index].Item2();
            }
            else throw new ArgumentException("Inconsistent factory percentages");
        }

        private int PercentageToIndex(int pencentage)
        {
            int accPercentage = 0;
            int index = 0;

            while (accPercentage < pencentage && index < _factories.Count)
            {
                accPercentage += _factories[index].Item1;
                index++;
            }

            return index;
        }
    }
}