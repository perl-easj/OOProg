using System;
using System.Collections.Generic;

namespace SWCClasses.Logic
{
    public class Filtering<T>
    {
        /// <summary>
        /// Filter using a single filtering condition
        /// </summary>
        public static IEnumerable<T> FilterValues(IEnumerable<T> values, IFilterCondition<T> filterCondition)
        {
            List<T> filteredValues = new List<T>();

            foreach (var value in values)
            {
                if (filterCondition.Condition(value))
                {
                    filteredValues.Add(value);
                }
            }

            return filteredValues;
        }

        /// <summary>
        /// Filter using multiple filtering conditions
        /// </summary>
        public static IEnumerable<T> MultipleFilterValues(IEnumerable<T> values, IEnumerable<IFilterCondition<T>> filterConditions)
        {
            IEnumerable<T> filteredValues = values;

            foreach (IFilterCondition<T> filterCondition in filterConditions)
            {
                filteredValues = FilterValues(filteredValues, filterCondition);
            }

            return filteredValues;
        }

        /// <summary>
        /// Filter using a filtering function as an argument
        /// </summary>
        public static IEnumerable<T> FilterUsingFunctionArgument(IEnumerable<T> values, Func<T, bool> conditionFunc)
        {
            List<T> filteredValues = new List<T>();

            foreach (var value in values)
            {
                if (conditionFunc(value))
                {
                    filteredValues.Add(value);
                }
            }

            return filteredValues;
        }
    }
}