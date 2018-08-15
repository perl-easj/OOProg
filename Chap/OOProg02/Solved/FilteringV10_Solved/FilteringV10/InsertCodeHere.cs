using System;
using System.Collections.Generic;

namespace FilteringV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            List<int> values = new List<int>() {12, 24, 9, 10, 6, 3, 45};

            #region Single-condition filtering
            List<int> filteredValues = Filter.FilterValues(values, new FilterOddNumbers());
            Console.WriteLine("Filter odd numbers:");
            foreach (var value in filteredValues)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine();

            filteredValues = Filter.FilterValues(values, new FilterBelow20());
            Console.WriteLine("Filter below 20:");
            foreach (var value in filteredValues)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine();

            filteredValues = Filter.FilterValues(values, new FilterDivisibleBy9());
            Console.WriteLine("Filter divisible by 9:");
            foreach (var value in filteredValues)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine();
            #endregion


            #region Multi-condition filtering
            List<IFilterCondition> filterConditions = new List<IFilterCondition>();
            filterConditions.Add(new FilterOddNumbers());
            filterConditions.Add(new FilterBelow20());
            filterConditions.Add(new FilterDivisibleBy9());

            filteredValues = Filter.MultipleFilterValues(values, filterConditions);
            Console.WriteLine("All filters:");
            foreach (var value in filteredValues)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine();
            #endregion


            #region Filtering with function-type parameter
            // ...and now some slightly weird stuff...
            Console.WriteLine("Filtering using a function parameter:");
            Filter.FilterUsingFunctionArgument(values, value => (value % 2) != 0).ForEach(value => Console.Write($" {value} "));
            Console.WriteLine(); 
            #endregion

            // The LAST line of code should be ABOVE this line
        }
    }
}