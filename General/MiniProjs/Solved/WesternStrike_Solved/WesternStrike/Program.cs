using System;
using WesternStrike.Characters.Types.Indian;
using WesternStrike.Characters.Types.PaleFace;
using WesternStrike.Combat;

// ReSharper disable UnusedParameter.Local

namespace WesternStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            CombatManager.DoCombat(new IndianGroup(), new PaleFaceGroup());

            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
