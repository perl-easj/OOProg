using System;

namespace NaiveRPG
{
    public class Game
    {
        public void Run()
        {
            Character aChar = new Character("Sigrid");

            // What does the Character own right now?
            Console.WriteLine("The game is starting");
            Console.WriteLine($"{aChar.Name} now owns:");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Money  :  {aChar.GoldOwned} gold");
            Console.WriteLine($"Boots  :  {(aChar.BootsOwned == null ? "(none)" : aChar.BootsOwned.ToString())}");
            Console.WriteLine($"Shield :  {(aChar.ShieldOwned == null ? "(none)" : aChar.ShieldOwned.ToString())}");
            Console.WriteLine($"Sword  :  {(aChar.SwordOwned == null ? "(none)" : aChar.SwordOwned.ToString())}");
            Console.WriteLine();
            Console.WriteLine();

            Bear aBear = new Bear();
            Troll aTroll = new Troll("Brutus");

            // Kill Bear
            while (!aBear.Dead)
            {
                // Character always deals 7 in damage...
                aBear.ReceiveDamage(7);
            }

            // Loot Bear
            aChar.GoldOwned = aChar.GoldOwned + aBear.GoldOwned;
            if (aBear.BootsToLoot != null)
            {
                aChar.BootsOwned = aBear.BootsToLoot;
            }

            // Kill Troll
            while (!aTroll.Dead)
            {
                // Character always deals 7 in damage...
                aTroll.ReceiveDamage(7);
            }

            // Loot Troll
            aChar.GoldOwned = aChar.GoldOwned + aTroll.GoldOwned;
            if (aTroll.SwordToLoot != null)
            {
                aChar.SwordOwned = aTroll.SwordToLoot;
            }
            if (aTroll.ShieldToLoot != null)
            {
                aChar.ShieldOwned = aTroll.ShieldToLoot;
            }

            // What does the Character own right now?
            Console.WriteLine("The game is over");
            Console.WriteLine($"{aChar.Name} now owns:");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Money  :  {aChar.GoldOwned} gold");
            Console.WriteLine($"Boots  :  {(aChar.BootsOwned == null ? "(none)" : aChar.BootsOwned.ToString())}");
            Console.WriteLine($"Shield :  {(aChar.ShieldOwned == null ? "(none)" : aChar.ShieldOwned.ToString())}");
            Console.WriteLine($"Sword  :  {(aChar.SwordOwned == null ? "(none)" : aChar.SwordOwned.ToString())}");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}