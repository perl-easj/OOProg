using System;
using System.Collections.Generic;

namespace AdvLINQ
{
    public abstract class AggregateCalculator<T, V>
    {
        public T Aggregate(IEnumerable<V> collection)
        {
            T value = InitialAggregateValue();
            foreach (V item in collection)
            {
                value = UpdateAggregateValue(value, item);
            }
            return value;
        }

        protected abstract T InitialAggregateValue();
        protected abstract T UpdateAggregateValue(T value, V item);

        public static T Aggregate(
            IEnumerable<V> collection, 
            Func<T> initialValueFunc,
            Func<T, V, T> updateValueFunc)
        {
            T value = initialValueFunc();
            foreach (V item in collection)
            {
                value = updateValueFunc(value, item);
            }
            return value;
        }

        public static T Aggregate(
            IEnumerable<V> collection,
            T initialValue,
            Func<T, V, T> updateValueFunc)
        {
            return Aggregate(collection, () => initialValue, updateValueFunc);
        }
    }
}