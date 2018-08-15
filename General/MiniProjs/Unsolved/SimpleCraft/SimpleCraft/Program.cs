using System;
using System.Collections.Generic;
using SimpleCraft.Characters;
using SimpleCraft.GUI;
using SimpleCraft.World;
// ReSharper disable UnusedParameter.Local

namespace SimpleCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            #region World Setup
            Character c1 = new Character("Aziz", 200, 2, 2);
            Character c2 = new Character("Borax", 250, 3, 5);
            Character c3 = new Character("Cersei", 200, 6, 3);
            Character c4 = new Character("Dora", 200, 8, 8);
            List<Character> characters = new List<Character> { c1, c2, c3, c4 };

            GameWorld world = new GameWorld(characters, 100);
            #endregion

            #region User Interaction
            string userInputStr = "";
            while (userInputStr != "qqq")
            {
                if (Console.KeyAvailable)
                {
                    userInputStr += Console.ReadKey(true).KeyChar.ToString();
                    SimpleGUI.SetCursorForUserInput();
                    Console.Write(userInputStr);
                }

                if (userInputStr.Length == 3 && userInputStr != "qqq")
                {
                    UserInput input = new UserInput(userInputStr);

                    if (input.IsValid)
                    {
                        world.SCManager.AddSpellCast(input.ShortName, input.X, input.Y, world.Clock.Time + 1);
                    }

                    userInputStr = "";
                    SimpleGUI.ResetUserInput();
                }
            } 
            #endregion
        }
    }
}
