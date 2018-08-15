using System;
using CalculationProxy.CalcByProxy;
using CalculationProxy.Common;

namespace CalculationProxy
{
    /// <summary>
    /// Class for invoking a test of the calculation (with or without proxy).
    /// </summary>
    public class CalculatorTest
    {
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());

        public static void Run(int xMax = 5, int yMax = 5)
        {
            Coordinate.XMax = xMax;
            Coordinate.YMax = yMax;

            bool useProxy = AskUserForStrategy();
            Run(useProxy);
        }

        private static void Run(bool useProxy)
        {
            ICalculate theCalculator = CalculatorFactory.Create(useProxy);

            for (int i = 0; i < 1000; i++)
            {
                int x = _generator.Next(0, Coordinate.XMax) + 1;
                int y = _generator.Next(0, Coordinate.YMax) + 1;
                Coordinate c = new Coordinate(x,y);
                Console.WriteLine($"Result of calculation #{i:000}, using ({x},{y}) : {theCalculator.Calculate(c)} {CacheReport(useProxy)}");
            }
        }

        private static string CacheReport(bool useProxy)
        {
            return useProxy ? $"(No. of cached values {Cache.NoOfCachedValues})" : "";
        }

        private static bool AskUserForStrategy()
        {
            Console.Write("Type (r) for real calculation, (p) for calculation by proxy ->  ");
            string response = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            if (response == "r" || response == "p")
            {
                return response == "p";
            }

            return AskUserForStrategy();
        }
    }
}