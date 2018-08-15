using System;

namespace CalculationSimulation
{
    /// <summary>
    /// This class manages the execution of a calculation simulation
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Runs the simulation
        /// </summary>
        public static void Run(int noOfIterations, int xDimension, int yDimension, bool useCache)
        {
            Simulator theSimulator = new Simulator(xDimension, yDimension, useCache);
            Random theGenerator = new Random();

            // Runs the simulation for the specified number of times
            for (int iteration = 0; iteration < noOfIterations; iteration++)
            {
                int x = theGenerator.Next(0, xDimension);
                int y = theGenerator.Next(0, yDimension);
                int value = theSimulator.Calculate(x, y);
                Console.WriteLine("Iteration {0:000} :   ({1},{2}) => {3}", iteration, x, y, value);
            }
        }
    }
}
