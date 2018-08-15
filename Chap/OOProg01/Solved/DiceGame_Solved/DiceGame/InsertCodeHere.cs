using System;

namespace DiceGame
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            DiceCup cup = new DiceCup();
            Console.WriteLine($"Total value is {cup.TotalValue}");

            cup.Shake();
            Console.WriteLine($"Total value is {cup.TotalValue}");

            cup.Shake();
            Console.WriteLine($"Total value is {cup.TotalValue}");

            DieNSides d100 = new DieNSides(100);
            d100.Roll();
            Console.WriteLine($"100-sided die shows {d100.FaceValue}");

            // The LAST line of code should be ABOVE this line
        }
    }
}