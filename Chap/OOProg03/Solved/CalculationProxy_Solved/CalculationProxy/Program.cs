using System;
// ReSharper disable UnusedParameter.Local

namespace CalculationProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run calculator test.
            CalculatorTest.Run();

            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
