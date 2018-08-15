using System;
using System.Collections.Generic;

namespace StaticExamples
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            #region ListMethods test
            List<int> aList = new List<int> { 23, 86, 51, 11, 39 };

            int smallest = ListMethods.FindSmallestNumber(aList);
            Console.WriteLine($"The smallest number in the list is : {smallest}");

            int average = ListMethods.FindAverage(aList);
            Console.WriteLine($"The average of the list is : {average}");
            #endregion


            #region Car test
            Car car1 = new Car("ABC 123", 15000);
            Car car2 = new Car("DEF 456", 22000);
            Car car3 = new Car("HIJ 789", 8000);

            car1.LicensePlate = "CBA 321";
            car2.LicensePlate = "FED 654";
            car3.Price = 12000;

            Console.WriteLine(car1.LicensePlate);
            Console.WriteLine(car3.Price);

            Car.PrintUsageStatistics(); 
            #endregion

            // The LAST line of code should be ABOVE this line
        }
    }
}