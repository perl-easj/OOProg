using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizedSelection
{
    public class RandomSelector<T> : IRandomSelector<T>
    {
        public const double SumTolerance = 0.000001;

        private Random _rng;
        private double _tolerance;
        private List<ISelectee<T>> _selecteeList;


        public RandomSelector(List<T> items, List<double> probabilities, double tolerance = SumTolerance)
        {
            _tolerance = tolerance;
            _rng = new Random(Guid.NewGuid().GetHashCode());

            if (items == null || probabilities == null || items.Count != probabilities.Count)
            {
                throw new ArgumentException("RandomSelector constructor parameter error");
            }

            double probSum = probabilities.Sum();
            if (Math.Abs(probSum - 1.0) > _tolerance)
            {
                throw new ArgumentException("RandomSelector constructor invalid probabilities");
            }

            _selecteeList = new List<ISelectee<T>>();
            for (int i = 0; i < items.Count; i++)
            {
                _selecteeList.Add(new SelecteeImpl<T>(items[i], probabilities[i]));
            }

            foreach (var selecteeItem in _selecteeList)
            {
                Console.WriteLine(selecteeItem);
            }
        }

        public T Select()
        {
            double accProb = _rng.NextDouble();

            int chosenIndex = 0;
            double chosenAccProb = _selecteeList[0].Probability;

            while (accProb > chosenAccProb && chosenIndex < (_selecteeList.Count - 1))
            {
                chosenIndex++;
                chosenAccProb += _selecteeList[chosenIndex].Probability;
            }

            return _selecteeList[chosenIndex].Selectee;
        }
    }
}