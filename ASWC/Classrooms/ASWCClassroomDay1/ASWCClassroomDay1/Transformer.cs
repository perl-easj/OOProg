using System;
using System.Collections.Generic;

namespace ASWCClassroomDay1
{
    public abstract class Transformer
    {
        public List<V> TransformItems<T, V>(List<T> items)
        {
            List<V> transformedItems = new List<V>();
            foreach (T item in items)
            {
                V transformedItem = TransformItem<T, V>(item);
                transformedItems.Add(transformedItem);
            }
            return transformedItems;
        }

        public abstract V TransformItem<T, V>(T item);


        public static List<V> TransformItems<T, V>(List<T> items, Func<T, V> transformer)
        {
            List<V> transformedItems = new List<V>();
            foreach (T item in items)
            {
                V transformedItem = transformer(item);
                transformedItems.Add(transformedItem);
            }
            return transformedItems;
        }
    }
}