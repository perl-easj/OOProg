using System.Collections.Generic;

namespace ASWCClassroomDay1
{
    public class HomeRolledAggregation
    {
        private int Product(IEnumerable<int> numbers)
        {
            int product = 1;
            foreach (int value in numbers)
            {
                product = product * value;
            }
            return product;
        }

        private int Sum(IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int value in numbers)
            {
                sum = sum + value;
            }
            return sum;
        }
    }
}