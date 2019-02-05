using System;
using System.Collections.Generic;
using System.Linq;
using RpgV0.WorldSetup;

namespace RpgV0
{
    /// <summary>
    /// This class is responsible for game configuration, i.e. it injects a dependency
    /// of a specific IWorldSetup implementation into the World object. It also contains
    /// a method for running a test of the game.
    /// </summary>
    public class GameConfigurator
    {
        private static IWorldSetup _setup;
        private static World _world;

        public static void SetupGame()
        {
            _setup = new WorldSetupDefault(); // THIS IS WHERE A SPECIFIC WORLD SETUP IS CHOSEN
            _world = new World(_setup);
        }

        public static void TestGame()
        {
            Dictionary<string, int> damPct = _world.DamagePercentages;

            Console.WriteLine("Current damage percentages          ");
            Console.WriteLine("------------------------------------");
            foreach (var item in damPct)
            {
                Console.WriteLine($"{item.Key.PadRight(25)} {item.Value} %");
            }
            Console.WriteLine();
            Console.WriteLine($"Average damage percentage for players: {damPct.Values.Average():F1} %");
        }
    }
}