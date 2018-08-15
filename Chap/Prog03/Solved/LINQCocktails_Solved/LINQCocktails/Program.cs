using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create ingredients
            Ingredient ingVodka = new Ingredient("Vodka", 15, 40);
            Ingredient ingRum = new Ingredient("Rum", 15, 40);
            Ingredient ingGin = new Ingredient("Gin", 15, 40);
            Ingredient ingTripleSec = new Ingredient("Triple Sec", 20, 30);
            Ingredient ingCola = new Ingredient("Cola", 1, 0);
            Ingredient ingLimeJuice = new Ingredient("Lime Juice", 2, 0);
            Ingredient ingCranJuice = new Ingredient("Cranberry Juice", 2, 0);
            Ingredient ingGingerBeer = new Ingredient("Ginger Beer", 2, 4);
            Ingredient ingMinWater = new Ingredient("Mineral Water", 1, 0);

            List<Ingredient> ingredients = new List<Ingredient>
            {
                ingVodka,
                ingRum,
                ingGin,
                ingTripleSec,
                ingCola,
                ingLimeJuice,
                ingCranJuice,
                ingGingerBeer,
                ingMinWater
            };
            #endregion

            #region Create cocktails
            Cocktail c1 = new Cocktail("Long Island Ice Tea");
            c1.AddIngredient("Rum", 3);
            c1.AddIngredient("Vodka", 3);
            c1.AddIngredient("Gin", 3);
            c1.AddIngredient("Cola", 9);

            Cocktail c2 = new Cocktail("Moscow Mule");
            c2.AddIngredient("Vodka", 4);
            c2.AddIngredient("Lime Juice", 3);
            c2.AddIngredient("Ginger Beer", 10);

            Cocktail c3 = new Cocktail("Cosmopolitan");
            c3.AddIngredient("Vodka", 4);
            c3.AddIngredient("Triple Sec", 2);
            c3.AddIngredient("Lime Juice", 6);
            c3.AddIngredient("Cranberry Juice", 6);

            Cocktail c4 = new Cocktail("Mojito");
            c4.AddIngredient("Rum", 4);
            c4.AddIngredient("Mineral Water", 10);
            c4.AddIngredient("Lime Juice", 2);

            List<Cocktail> cocktails = new List<Cocktail> { c1, c2, c3, c4 };
            #endregion

            #region Query #1
            var queryResult1 = from c in cocktails
                               select c.Name;

            Console.WriteLine("#1");
            Console.WriteLine("------------------");
            foreach (var element in queryResult1)
            {
                Console.WriteLine($"{element}");
            }
            Console.WriteLine();
            #endregion

            #region Query #2
            var queryResult2 = from c in cocktails
                               select new
                               {
                                   c.Name,
                                   c.Ingredients
                               };

            Console.WriteLine("#2");
            Console.WriteLine("------------------");
            foreach (var element in queryResult2)
            {
                Console.WriteLine($"{element.Name}");
                foreach (var collElement in element.Ingredients)
                {
                    Console.WriteLine($"  {collElement.Key} {collElement.Value} cl.");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion

            #region Query #3
            var queryResult3 = from c in cocktails
                               select new
                               {
                                   c.Name,
                                   AlcoIng = from coIng in c.Ingredients
                                             join ing in ingredients
                                             on coIng.Key equals ing.Name
                                             where ing.AlcoholPercent > 10
                                             select ing.Name
                               };

            Console.WriteLine("#3");
            Console.WriteLine("------------------");
            foreach (var element in queryResult3)
            {
                Console.WriteLine($"{element.Name}");
                foreach (var collElement in element.AlcoIng)
                {
                    Console.WriteLine($"  {collElement}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion

            #region Query #4
            var queryResult4 = from c in cocktails
                               select new
                               {
                                   c.Name,
                                   Price = (from coIng in c.Ingredients
                                            join ing in ingredients
                                            on coIng.Key equals ing.Name
                                            select coIng.Value * ing.PricePerCl).Sum()
                               };

            Console.WriteLine("#4");
            Console.WriteLine("------------------");
            foreach (var element in queryResult4)
            {
                Console.WriteLine($"{element.Name,-25}: {element.Price,4} kr.");
            }
            Console.WriteLine();
            #endregion

            #region Query #5
            var queryResult5 = from c in cocktails
                               select new
                               {
                                   c.Name,
                                   Strength = (from coIng in c.Ingredients
                                               join ing in ingredients
                                               on coIng.Key equals ing.Name
                                               select coIng.Value * ing.AlcoholPercent).Sum() /
                                              (from coIng in c.Ingredients
                                               join ing in ingredients
                                               on coIng.Key equals ing.Name
                                               select coIng.Value).Sum()
                               };

            Console.WriteLine("#5");
            Console.WriteLine("------------------");
            foreach (var element in queryResult5)
            {
                Console.WriteLine($"{element.Name,-25}: ({element.Strength:0.00} %)");
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
