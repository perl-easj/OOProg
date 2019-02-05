using System;

namespace RpgV0
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConfigurator.SetupGame();
            GameConfigurator.TestGame();
            Wait();
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
