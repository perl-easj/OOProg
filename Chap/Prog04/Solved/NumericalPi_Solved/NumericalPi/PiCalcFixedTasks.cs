using System;
using System.Threading.Tasks;

namespace NumericalPi
{
    public class PiCalcFixedTasks
    {
        public double Calculate(int iterations)
        {
            int insideUnitCircleA = 0;
            int insideUnitCircleB = 0;
            int insideUnitCircleC = 0;
            int insideUnitCircleD = 0;

            Task taskA = new Task(() => { insideUnitCircleA = Iterate(iterations / 4); });
            Task taskB = new Task(() => { insideUnitCircleB = Iterate(iterations / 4); });
            Task taskC = new Task(() => { insideUnitCircleC = Iterate(iterations / 4); });
            Task taskD = new Task(() => { insideUnitCircleD = Iterate(iterations / 4); });

            taskA.Start();
            taskB.Start();
            taskC.Start();
            taskD.Start();

            Task.WaitAll(taskA, taskB, taskC, taskD);

            return (insideUnitCircleA + insideUnitCircleB + insideUnitCircleC + insideUnitCircleD) * 4.0 / iterations;
        }

        public int Iterate(int iterations)
        {
            Random generator = new Random(Guid.NewGuid().GetHashCode());
            int insideUnitCircle = 0;

            for (int i = 0; i < iterations; i++)
            {
                double x = generator.NextDouble();
                double y = generator.NextDouble();

                if (x * x + y * y < 1.0)
                {
                    insideUnitCircle++;
                }
            }

            return insideUnitCircle;
        }
    }
}