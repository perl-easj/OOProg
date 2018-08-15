using System;
using System.Diagnostics;

namespace NumericalPi
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            PiCalc calculator = new PiCalc();
            
            Console.WriteLine("Started");
            watch.Start();
            double numPi = calculator.Calculate(100000000);
            watch.Stop();
            Console.WriteLine("Done");

            Console.WriteLine($"Numeric PI = {numPi:0.000000}");
            Console.WriteLine($"Real PI    = {Math.PI:0.000000}");
            Console.WriteLine($"Took {watch.ElapsedMilliseconds} milliSecs");
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");

            Console.ReadKey();
        }
    }
}
