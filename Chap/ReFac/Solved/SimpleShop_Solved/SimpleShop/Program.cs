using System;
// ReSharper disable UnusedParameter.Local

namespace SimpleShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester aTester = new Tester();
            aTester.Run();

            Console.WriteLine();
            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }
}
