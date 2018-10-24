using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedParameter.Local

namespace LINQDrink
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create drinks
            List<Drink> drinks = new List<Drink>();
            drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
            drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
            drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
            drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
            drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
            drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
            drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
            drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
            drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
            drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
            #endregion

            // The queries with the "A" suffix are written with SQL-like syntax
            // The queries with the "B" suffix are written with Fluent syntax

            #region Query #1A
            var qr1A = from d in drinks
                       select d.Name;

            Console.WriteLine("#1A - Names of all drinks");
            Console.WriteLine("------------------------");
            foreach (var item in qr1A)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query #1B
            var qr1B = drinks.Select(d => d.Name);

            Console.WriteLine("#1B - Names of all drinks");
            Console.WriteLine("------------------------");
            foreach (var item in qr1B)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query #2A
            var qr2A = from d in drinks
                       where d.AlcoholicPartAmount == 0
                       select d.Name;

            Console.WriteLine("#2A - Names of all drinks without alcohol");
            Console.WriteLine("----------------------------------------");
            foreach (var item in qr2A)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query #2B
            var qr2B = drinks
                       .Where(d => d.AlcoholicPartAmount == 0)
                       .Select(d => d.Name);

            Console.WriteLine("#2B - Names of all drinks without alcohol");
            Console.WriteLine("----------------------------------------");
            foreach (var item in qr2B)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query #3A
            var qr3A = from d in drinks
                       where d.AlcoholicPartAmount > 0
                       select new { d.Name, d.AlcoholicPart, d.AlcoholicPartAmount };

            Console.WriteLine("#3A - Name, alcohol part and alcohol amount for all drinks with alcohol");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var item in qr3A)
            {
                Console.WriteLine($"{item.Name} contains {item.AlcoholicPartAmount} cl. {item.AlcoholicPart}");
            }
            Console.WriteLine();
            #endregion

            #region Query #3B

            var qr3B = drinks
                       .Where(d => d.AlcoholicPartAmount > 0)
                       .Select(d => new {d.Name, d.AlcoholicPart, d.AlcoholicPartAmount});

            Console.WriteLine("#3B - Name, alcohol part and alcohol amount for all drinks with alcohol");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var item in qr3B)
            {
                Console.WriteLine($"{item.Name} contains {item.AlcoholicPartAmount} cl. {item.AlcoholicPart}");
            }
            Console.WriteLine();
            #endregion

            #region Query #4A
            var qr4A = from d in drinks
                       orderby d.Name
                       select d.Name;

            Console.WriteLine("#4A - Names of all drinks in alphabetical order");
            Console.WriteLine("----------------------------------------------");
            foreach (var item in qr4A)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query #4B
            var qr4B = drinks
                       .OrderBy(d => d.Name)
                       .Select(d => d.Name);

            Console.WriteLine("#4B - Names of all drinks in alphabetical order");
            Console.WriteLine("----------------------------------------------");
            foreach (var item in qr4B)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query #5A
            int qr5A = (from d in drinks
                        select d.AlcoholicPartAmount).Sum();

            Console.WriteLine("#5A - Total amount of alcohol in the drinks");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"{qr5A} cl.");
            Console.WriteLine();
            #endregion

            #region Query #5B
            int qr5B = drinks
                       .Select(d => d.AlcoholicPartAmount)
                       .Sum();

            Console.WriteLine("#5B - Total amount of alcohol in the drinks");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"{qr5B} cl.");
            Console.WriteLine();
            #endregion

            #region Query #6A
            double qr6A = (from d in drinks
                           where d.AlcoholicPartAmount > 0
                           select d.AlcoholicPartAmount).Average();

            Console.WriteLine("#6A - Average amount of alcohol in drinks with alcohol");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{qr6A} cl.");
            Console.WriteLine();
            #endregion

            #region Query #6B
            double qr6B = drinks
                          .Where(d => d.AlcoholicPartAmount > 0)
                          .Select(d => d.AlcoholicPartAmount)
                          .Average();

            Console.WriteLine("#6B - Average amount of alcohol in drinks with alcohol");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{qr6B} cl.");
            Console.WriteLine();
            #endregion

            #region Query #7A
            var qr7A = from d in drinks
                       group d by d.AlcoholicPart;

            Console.WriteLine("#7A - Name and alcohol amount of each drink, grouped by alcohol part ");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var group in qr7A)
            {
                Console.WriteLine();
                Console.WriteLine($"Drinks with {group.Key}");
                Console.WriteLine("-------------------------");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.Name}  ({item.AlcoholicPartAmount} cl.)");
                }
            }
            Console.WriteLine();
            #endregion

            #region Query #7B
            var qr7B = drinks.GroupBy(d => d.AlcoholicPart);

            Console.WriteLine("#7B - Name and alcohol amount of each drink, grouped by alcohol part ");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var group in qr7B)
            {
                Console.WriteLine();
                Console.WriteLine($"Drinks with {group.Key}");
                Console.WriteLine("-------------------------");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.Name}  ({item.AlcoholicPartAmount} cl.)");
                }
            }
            Console.WriteLine();
            #endregion

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
