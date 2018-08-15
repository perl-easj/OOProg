using System;

namespace CarDealershipV05
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Car carNo1 = new Car("BJ43009", "Ford", "Mondeo", 120000);
            Car carNo2 = new Car("BJ43009", "Ford", "Mondeo", 120000);
            Car carNo3 = new Car("BJ43009", "Opel", "Kadett", 55000);
            Car carNo4 = carNo3;
            Car carNo5 = new Car("ST88711", "Ford", "Mondeo", 120000);

            Console.WriteLine();
            Console.WriteLine(carNo1);
            Console.WriteLine(carNo2);
            Console.WriteLine(carNo3);
            Console.WriteLine(carNo4);
            Console.WriteLine(carNo5);

            Console.WriteLine();
            Console.WriteLine($"carNo1 is equal to carNo2 : {carNo1.Equals(carNo2)}");
            Console.WriteLine($"carNo1 is equal to carNo3 : {carNo1.Equals(carNo3)}");
            Console.WriteLine($"carNo1 is equal to carNo4 : {carNo1.Equals(carNo4)}");
            Console.WriteLine($"carNo3 is equal to carNo4 : {carNo3.Equals(carNo4)}");
            Console.WriteLine($"carNo1 is equal to carNo5 : {carNo1.Equals(carNo5)}");

            Console.WriteLine();
            Console.WriteLine($"carNo1 == carNo2 : {carNo1 == carNo2}");
            Console.WriteLine($"carNo1 == carNo3 : {carNo1 == carNo3}");
            Console.WriteLine($"carNo1 == carNo4 : {carNo1 == carNo4}");
            Console.WriteLine($"carNo3 == carNo4 : {carNo3 == carNo4}");
            Console.WriteLine($"carNo1 == carNo5 : {carNo1 == carNo5}");

            // The LAST line of code should be ABOVE this line
        }
    }
}