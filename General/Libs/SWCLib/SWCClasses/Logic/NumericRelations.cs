using System;
using System.Collections.Generic;
using System.Linq;

namespace SWCClasses.Logic
{
    public class NumericRelations
    {
        public static int Largest(int a, int b)
        {
            return a > b ? a : b;
        }

        public static double Largest(double a, double b)
        {
            return a > b ? a : b;
        }

        public static int Smallest(int a, int b)
        {
            return a < b ? a : b;
        }

        public static double Smallest(double a, double b)
        {
            return a < b ? a : b;
        }

        public static T LargestItemInCollection<T>(IEnumerable<T> collection)
        {
            var enumerable = collection.ToList();
            CheckCollection(enumerable);
            return enumerable.Max();
        }

        public static T SmallestItemInCollection<T>(IEnumerable<T> collection)
        {
            var enumerable = collection.ToList();
            CheckCollection(enumerable);
            return enumerable.Min();
        }

        public static double SumOfItemsInCollection(IEnumerable<double> collection)
        {
            return collection.Sum();
        }

        public static int SumOfItemsInCollection(IEnumerable<int> collection)
        {
            return collection.Sum();
        }

        public static double SumOfItemsInCollection<T>(IEnumerable<T> collection, Func<T, double> selector)
        {
            return collection.Sum(selector);
        }

        public static double AverageOfItemsInCollection(IEnumerable<double> collection)
        {
            return collection.Average();
        }

        public static double AverageOfItemsInCollection(IEnumerable<int> collection)
        {
            return collection.Average();
        }

        public static double AverageOfItemsInCollection<T>(IEnumerable<T> collection, Func<T, double> selector)
        {
            return collection.Average(selector);
        }

        private static void CheckCollection<T>(IEnumerable<T> collection)
        {
            if (!collection.Any())
            {
                throw new ArgumentException("Collection must contain items");
            }
        }
    }
}
