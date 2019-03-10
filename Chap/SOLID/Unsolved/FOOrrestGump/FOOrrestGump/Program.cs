using System;
using FOOrrestGump.FGScenario;
// ReSharper disable UnusedParameter.Local

namespace FOOrrestGump
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSpecificScenario();
            Wait();
        }

        private static void RunSpecificScenario()
        {
            ForrestGumpGenerator fgGenerator = new ForrestGumpGenerator();
            ChocolateBoxGenerator cbGenerator = new ChocolateBoxGenerator();

            ForrestGump gump = fgGenerator.GenerateForrestGump();
            ChocolateBox box = cbGenerator.GenerateChocolateBox();

            gump.SayFavoriteProverb();
            while (box.ChocolateLeft)
            {
                gump.Eat(box.TakeAChocolate());
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void Wait()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close application");
            Console.ReadKey();
        }
    }
}
