using System;
using System.Collections.Generic;

namespace AdvLINQ
{
    public abstract class Transformer
    {
        public List<V> TransformItems<T, V>(List<T> items)
        {
            List<V> result = new List<V>();
            foreach (T item in items)
            {
                V transformedItem = TransformItem<T, V>(item);
                result.Add(transformedItem);
            }
            return result;
        }

        public abstract V TransformItem<T, V>(T item);

        public static List<V> TransformItems<T, V>(List<T> items, Func<T,V> transformer)
        {
            List<V> result = new List<V>();
            foreach (T item in items)
            {
                V transformedItem = transformer(item);
                result.Add(transformedItem);
            }
            return result;
        }
    }
}