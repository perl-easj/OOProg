using System;
using System.Collections.Generic;
using System.Linq;

namespace SWCClasses.ConsoleUI
{
    public class CollectionPrint
    {
        public static void PrintCollectionItems<T>(IEnumerable<T> collection, string header = "", int blanksAfter = 0)
        {
            if (!string.IsNullOrEmpty(header))
            {
                Console.WriteLine(header);
                Console.WriteLine("-----------------------------");
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < blanksAfter; i++)
            {
                Console.WriteLine();
            }
        }

        public static void PrintDictionaryKeys<K,V>(Dictionary<K,V> dictionary, string header = "", int blanksAfter = 0)
        {
            PrintCollectionItems(dictionary.Keys, header, blanksAfter);
        }

        public static void PrintDictionaryValues<K, V>(Dictionary<K, V> dictionary, string header = "", int blanksAfter = 0)
        {
            PrintCollectionItems(dictionary.Values, header, blanksAfter);
        }

        public static void PrintDictionary<K, V>(Dictionary<K, V> dictionary, string header = "", int blanksAfter = 0)
        {
            PrintCollectionItems(dictionary.Select(item => $"Key: {item.Key}, Value: {item.Value}"), header, blanksAfter);
        }
    }
}