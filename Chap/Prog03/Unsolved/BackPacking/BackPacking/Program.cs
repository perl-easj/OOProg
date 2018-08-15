using System;
using System.Collections.Generic;
using BackPacking.Algorithms;
using BackPacking.Item;

namespace BackPacking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BackPackItem> items = new List<BackPackItem>();
            items.Add(new BackPackItem("Rope", 1.5, 15));
            items.Add(new BackPackItem("Water", 2, 30));
            items.Add(new BackPackItem("Extra Water", 2, 20));
            items.Add(new BackPackItem("Toilet Paper", 0.5, 8));
            items.Add(new BackPackItem("Coffee", 0.5, 6));
            items.Add(new BackPackItem("Mosquito Net", 1, 15));
            items.Add(new BackPackItem("Pocket Knife", 0.3, 10));
            items.Add(new BackPackItem("Laptop", 2, 20));
            items.Add(new BackPackItem("Fishing Rod", 2.5, 30));
            items.Add(new BackPackItem("Mini Stove", 1.5, 20));
            items.Add(new BackPackItem("Tent", 5, 80));
            items.Add(new BackPackItem("Chocolate", 0.4, 5));
            items.Add(new BackPackItem("First Aid Kit", 1.2, 25));
            items.Add(new BackPackItem("Sleeping Bag", 2, 25));
            items.Add(new BackPackItem("Food", 1.5, 20));
            items.Add(new BackPackItem("Extra Food", 1.5, 12));
            items.Add(new BackPackItem("SunScreen", 1, 20));

            IBackPackingSolver solver = new BackPackingSolverStupid(items, 15.0);
            solver.Run();

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
