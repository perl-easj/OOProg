using System;

namespace SOLID.Liskov.Company
{
    public class Employee : IEmployee
    {
        private const int lowerLimit = 10000;
        private const int upperLimit = 1000000;
        private static Random _random = new Random();

        // Not sure I want to work in this place...
        public virtual int GetYearlySalary()
        {
            return _random.Next(lowerLimit, upperLimit);
        }
    }
}