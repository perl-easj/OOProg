using System;
using System.Collections.Generic;

namespace ASWCClassroomDay1
{
    public abstract class AggregateCalculator<T, V>
    {
        public T Aggregate(IEnumerable<V> collection)
        {
            T result = InitialAggregateValue();
            foreach (V item in collection)
            {
                result = UpdateAggregateValue(result, item);
            }
            return result;
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
    }
}