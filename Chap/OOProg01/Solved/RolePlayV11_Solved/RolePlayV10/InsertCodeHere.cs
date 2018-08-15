using System;

namespace RolePlayV11
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Warrior warriorA = new Warrior("Ragnar", 200);
            Warrior warriorB = new Warrior("Lagertha", 240);

            Console.WriteLine("Just after creation:");
            Console.WriteLine($"Warrior A is called {warriorA.Name}, is level {warriorA.Level}, and has {warriorA.HitPoints} hit points (Dead = {warriorA.Dead})");
            Console.WriteLine($"Warrior B is called {warriorB.Name}, is level {warriorB.Level}, and has {warriorB.HitPoints} hit points (Dead = {warriorB.Dead})");
            Console.WriteLine();

            warriorA.DecreaseHitPoints(180);
            warriorB.DecreaseHitPoints(180);

            Console.WriteLine("After first hits:");
            Console.WriteLine($"Warrior A is called {warriorA.Name}, is level {warriorA.Level}, and has {warriorA.HitPoints} hit points (Dead = {warriorA.Dead})");
            Console.WriteLine($"Warrior B is called {warriorB.Name}, is level {warriorB.Level}, and has {warriorB.HitPoints} hit points (Dead = {warriorB.Dead})");
            Console.WriteLine();

            warriorA.DecreaseHitPoints(50);
            warriorB.DecreaseHitPoints(50);

            Console.WriteLine("After second hits:");
            Console.WriteLine($"Warrior A is called {warriorA.Name}, is level {warriorA.Level}, and has {warriorA.HitPoints} hit points (Dead = {warriorA.Dead})");
            Console.WriteLine($"Warrior B is called {warriorB.Name}, is level {warriorB.Level}, and has {warriorB.HitPoints} hit points (Dead = {warriorB.Dead})");
            Console.WriteLine();

            // The LAST line of code should be ABOVE this line
        }
    }
}