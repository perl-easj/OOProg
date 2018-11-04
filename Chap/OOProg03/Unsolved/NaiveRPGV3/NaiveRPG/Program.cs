using System;
using NaiveRPG.Factories;
using NaiveRPG.GameManagement;

namespace NaiveRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFactory.Instance().ArmorFactory = new ArmorFactoryStandard();
            GameFactory.Instance().WeaponFactory = new WeaponFactoryStandard();
            GameFactory.Instance().ParticipantFactory = new ParticipantFactoryStandard();

            Game aGame = new Game();
            aGame.Run(5);

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close application.");
            Console.ReadKey();
        }
    }
}
