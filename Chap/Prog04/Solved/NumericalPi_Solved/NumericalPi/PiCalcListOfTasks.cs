using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumericalPi
{
    public class PiCalcListOfTasks
    {
        private List<int> _insideUnitCircle;

        public PiCalcListOfTasks()
        {
            _insideUnitCircle = new List<int>();
        }

        public double Calculate(int iterations, int noOfTasks)
        {
            int iterationsPerTask = iterations / noOfTasks;
            List<Task> tasks = new List<Task>();
            _insideUnitCircle.Clear();

            for (int taskNo = 0; taskNo < noOfTasks; taskNo++)
            {
                var no = taskNo;
                tasks.Add(new Task(() => { Iterate(no, iterationsPerTask); }));
                _insideUnitCircle.Add(0);
            }

            for (int taskNo = 0; taskNo < noOfTasks; taskNo++)
            {
                tasks[taskNo].Start();
            }

            Task.WaitAll(tasks.ToArray());

            return (_insideUnitCircle.Sum() * 4.0) / iterations;
        }

        public void Iterate(int taskNo, int iterations)
        {
            Random generator = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < iterations; i++)
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