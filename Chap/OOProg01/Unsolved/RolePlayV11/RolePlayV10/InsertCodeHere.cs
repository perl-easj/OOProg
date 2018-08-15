using System;

namespace RolePlayV11
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Warrior warriorA = new Warrior("Ragnar");
            Warrior warriorB = new Warrior("Lagertha");

            Console.WriteLine($"Warrior A is called {warriorA.Name} is level {warriorA.Level}");
            Console.WriteLine($"Warrior B is called {warriorB.Name} is level {warriorB.Level}");

            // The LAST line of code should be ABOVE this line
        }
    }
}