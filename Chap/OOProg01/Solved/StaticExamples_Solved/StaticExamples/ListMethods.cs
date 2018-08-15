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
        public static int FindSmallestNumber(List<int> numbers) // Updated
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

        public static int FindAverage(List<int> numbers) // Updated
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