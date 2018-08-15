using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumericalPi
{
    public class PiCalcParallel
    {
        private List<int> _insideUnitCircle;
        private int _iterationsPerParallel;

        public PiCalcParallel()
        {
            _insideUnitCircle = new List<int>();
            _iterationsPerParallel = 0;
        }

        public double Calculate(int iterations, int noOfParallels)
        {
            _iterationsPerParallel = iterations / noOfParallels;
            _insideUnitCircle.Clear();

            for (int taskNo = 0; taskNo < noOfParallels; taskNo++)
            {
                _insideUnitCircle.Add(0);
            }

            Parallel.For(0, noOfParallels, Iterate);

            return (_insideUnitCircle.Sum() * 4.0) / iterations;
        }

        public void Iterate(int taskNo)
        {
            Random generator = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < _iterationsPerParallel; i++)
            {
                double x = generator.NextDouble();
                double y = generator.NextDouble();

                if (x * x + y * y < 1.0)
                {
                    _insideUnitCircle[taskNo]++;
                }
            }
        }
    }
}