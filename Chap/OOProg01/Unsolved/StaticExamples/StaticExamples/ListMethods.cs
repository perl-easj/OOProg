using System;
using System.Collections.Generic;

namespace StaticExamples
{
    /// <summary>
    /// This class contains a few methods for 
    /// some common List operations
    /// </summary>
    public class ListMethods
    {
        public int FindSmallestNumber(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                int smallest = numbers[0];
                for (int index = 1; index < numbers.Count; index++)
                {
                    if (numbers[index] < smallest)
                    {
                        smallest = numbers[index];
                    }
                }
                return smallest;
            }
        }

        public int FindAverage(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                int sum = numbers[0];
                for (int index = 1; index < numbers.Count; index++)
                {
                    sum = sum + numbers[index];
                }
                return (sum / numbers.Count);
            }
        }
    }
}