using System;
using System.Collections.Generic;

namespace TestExampleA
{
    public class ListMethods
    {
        /// <summary>
        /// This method calculates the sum of the squares of the
        /// positive numbers in the list. 
        /// Examples: [2, 3, 5] = 2x2 + 3x3 + 5x5 = 4 + 9 + 25 = 38
        ///           [4, -2, 3] = 4x4 + 3x3 = 16 + 9 = 25 (-2 was excluded)
        /// If a null value or an empty list is given as parameter,
        /// the exception ArgumentException is thrown 
        /// </summary>
        public int SumOfSquaresOfPositives(List<int> numbers)
        {
            int sum = 0;

            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("Invalid list");
            }

            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    sum = sum + number * number;
                }
            }

            return sum;
        }
    }
}