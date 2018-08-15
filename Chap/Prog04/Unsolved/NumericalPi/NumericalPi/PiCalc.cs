using System;

namespace NumericalPi
{
    public class PiCalc
    {
        /// <summary>
        /// Executes the calculation of an 
        /// approximate value of pi.
        /// </summary>
        /// <param name="iterations">Number of iterations to perform</param>
        /// <returns>Approximate value of pi</returns>
        public double Calculate(int iterations)
        {
            int insideUnitCircle = Iterate(iterations);
            return insideUnitCircle * 4.0 / iterations;
        }

        /// <summary>
        /// Perform a number of "dart-throwing" simulations.
        /// </summary>
        /// <param name="iterations">Number of dart-throws to perform</param>
        /// <returns>Number of throws within the unit circle</returns>
        public int Iterate(int iterations)
        {
            Random _generator = new Random(Guid.NewGuid().GetHashCode());
            int insideUnitCircle = 0;

            for (int i = 0; i < iterations; i++)
            {
                double x = _generator.NextDouble();
                double y = _generator.NextDouble();

                if (x * x + y * y < 1.0)
                {
                    insideUnitCircle++;
                }
            }

            return insideUnitCircle;
        }
    }
}