using System;
using System.Collections.Generic;

namespace RandomizedSelection
{
    class Program
    {
        static void Main(string[] args)
        {
            int runs = 100;

            List<string> names = new List<string> { "Anders", "Bente", "Casper", "Dorthe" };
            List<double> namesProb = new List<double> { 0.2, 0.4, 0.1, 0.3 };
            Statistics<string> namesStat = new Statistics<string>(names);

            RandomSelector<string> rsName = new RandomSelector<string>(names, namesProb);
            for (int i = 0; i < runs; i++)
            {
                string nameSelected = rsName.Select();

                namesStat.Register(nameSelected);
                // Console.WriteLine(nameSelected);
            }

            Console.WriteLine();
            foreach (var entry in namesStat.Frequencies)
            {
                Console.WriteLine($"{entry.Key}, freq. {entry.Value:F3}");
            }

            Console.WriteLine();
            Console.WriteLine();


            List<ConsoleColor> colors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow};
            List<double> colorsProb = new List<double> { 0.15, 0.6, 0.25 };
            Statistics<ConsoleColor> colorsStat = new Statistics<ConsoleColor>(colors);

            RandomSelector<ConsoleColor> rsColor = new RandomSelector<ConsoleColor>(colors, colorsProb);
            ConsoleColor orgColor = Console.ForegroundColor;
            for (int i = 0; i < runs; i++)
            {
                ConsoleColor cc = rsColor.Select();

                colorsStat.Register(cc);
                //Console.ForegroundColor = cc;
                //Console.WriteLine(Console.ForegroundColor.ToString());
            }
            Console.ForegroundColor = orgColor;


            Console.WriteLine();
            foreach (var entry in colorsStat.Frequencies)
            {
                Console.WriteLine($"{entry.Key.ToString()}, freq. {entry.Value:F3}");
            }

            Console.ReadKey();
        }
    }
}
