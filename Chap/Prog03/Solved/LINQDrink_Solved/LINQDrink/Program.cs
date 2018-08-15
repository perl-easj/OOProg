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

            #region Query #1
            var queryResult1 = from d in drinks
                               select d.Name;

            Console.WriteLine("#1 - Names of all drinks");
            Console.WriteLine("------------------------");
            foreach (var element in queryResult1)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            #endregion

            #region Query #2
            var queryResult2 = from d in drinks
                               where d.AlcoholicPartAmount == 0
                               select d.Name;

            Console.WriteLine("#2 - Names of all drinks without alcohol");
            Console.WriteLine("----------------------------------------");
            foreach (var element in queryResult2)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            #endregion

            #region Query #3
            var queryResult3 = from d in drinks
                               where d.AlcoholicPartAmount > 0
                               select new { d.Name, d.AlcoholicPart, d.AlcoholicPartAmount };

            Console.WriteLine("#3 - Name, alcohol part and alcohol amount for all drinks with alcohol");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach (var element in queryResult3)
            {
                Console.WriteLine($"{element.Name} contains {element.AlcoholicPartAmount} cl. {element.AlcoholicPart}");
            }
            Console.WriteLine();
            #endregion

            #region Query #4
            var queryResult4 = from d in drinks
                               orderby d.Name
                               select d.Name;

            Console.WriteLine("#4 - Names of all drinks in alphabetical order");
            Console.WriteLine("----------------------------------------------");
            foreach (var element in queryResult4)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            #endregion

            #region Query #5
            int queryResult5 = (from d in drinks
                                select d.AlcoholicPartAmount).Sum();

            Console.WriteLine("#5 - Total amount of alcohol in the drinks");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"{queryResult5} cl.");
            Console.WriteLine();
            #endregion

            #region Query #6
            double queryResult6 = (from d in drinks
                                   where d.AlcoholicPartAmount > 0
                                   select d.AlcoholicPartAmount).Average();

            Console.WriteLine("#6 - Average amount of alcohol in drinks with alcohol");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"{queryResult6} cl.");
            Console.WriteLine();
            #endregion

            #region Query #7
            var queryResult7 = from d in drinks
                               where d.AlcoholicPart != "None"
                               group d by d.AlcoholicPart;

            Console.WriteLine("#7 - Name and alcohol amount of each drink, grouped by alcohol part ");
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var group in queryResult7)
            {
                Console.WriteLine();
                Console.WriteLine($"Drinks with {group.Key}");
                Console.WriteLine("-------------------------");
                foreach (var element in group)
                {
                    Console.WriteLine($"{element.Name}  ({element.AlcoholicPartAmount} cl.)");
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
