using System;
using System.Collections.Generic;

namespace LambdaAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog d1 = new Dog("King", 25);
            Dog d2 = new Dog("Tiny", 95);
            Dog d3 = new Dog("Rufus", 36);
            Dog d4 = new Dog("Spot", 55);
            Dog d5 = new Dog("Daisy", 8);
            List<Dog> dogs = new List<Dog>{ d1, d2, d3, d4, d5};

            // Print out all Dogs with a weight larger than 40 kg.
            

            // Print out all Dogs with a weight smaller than Rufus' weight.
            

            // Print out all Dogs with a name that contains an "i"
            


            KeepConsoleWindowOpen();
        }

        public static void ConditionalPrint<T>(List<T> objects, Predicate<T> pred)
        {
            Console.WriteLine();
            foreach (var item in objects.FindAll(pred))
            {
                Console.WriteLine(item);
            }
        }


        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
