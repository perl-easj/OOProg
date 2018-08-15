using System;

namespace RolePlayV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Warrior warriorA = new Warrior("Ragnar");
            Warrior warriorB = new Warrior("Lagertha");

            Console.WriteLine("Before calls of LevelUp()");
            Console.WriteLine($"Warrior A is called {warriorA.Name}, and is Level {warriorA.Level}");
            Console.WriteLine($"Warrior B is called {warriorB.Name}, and is Level {warriorB.Level}");
            Console.WriteLine();

            warriorA.LevelUp();
            warriorB.LevelUp();
            warriorB.LevelUp();
            warriorB.LevelUp();

            Console.WriteLine("After calls of LevelUp()");
            Console.WriteLine($"Warrior A is called {warriorA.Name}, and is Level {warriorA.Level}");
            Console.WriteLine($"Warrior B is called {warriorB.Name}, and is Level {warriorB.Level}");
            Console.WriteLine();

            // The LAST line of code should be ABOVE this line
        }
    }
}