using System;
using System.Collections.Generic;

namespace FilteringV10
{
    /// <summary>
    /// Class capable on filtering a List of integers
    /// in various ways
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// Filter using a single filtering condition
        /// </summary>
        public static List<int> FilterValues(List<int> values, IFilterCondition filterCondition)
        {
            List<int> filteredValues = new List<int>();

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
        public static List<int> MultipleFilterValues(List<int> values, List<IFilterCondition> filterConditions)
        {
            List<int> filteredValues = values;

            foreach (IFilterCondition filterCondition in filterConditions)
            {
                filteredValues = FilterValues(filteredValues, filterCondition);
            }

            return filteredValues;
        }

        /// <summary>
        /// Filter using a filtering function as an argument
        /// </summary>
        public static List<int> FilterUsingFunctionArgument(List<int> values, Func<int, bool> conditionFunc)
        {
            List<int> filteredValues = new List<int>();

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