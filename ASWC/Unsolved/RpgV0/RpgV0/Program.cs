using System;
using System.Collections.Generic;

namespace RpgV0
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWorldExample();
            Wait();
        }

        private static void RunWorldExample()
        {
            World theWorld = new World();
            Dictionary<string, int> damPct = theWorld.DamagePercentages;

            Console.WriteLine("Current damage percentages          ");
            Console.WriteLine("------------------------------------");
            foreach (var item in damPct)
            {
                Console.WriteLine($"{item.Key.PadRight(25)} {item.Value} %");
            }
            Console.WriteLine();
        }

        private static void Wait()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close application");
            Console.ReadKey();
        }
    }
}
