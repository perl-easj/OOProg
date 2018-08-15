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

            Console.WriteLine($"Warrior A is called {warriorA.Name}");
            Console.WriteLine($"Warrior B is called {warriorB.Name}");

            // The LAST line of code should be ABOVE this line
        }
    }
}