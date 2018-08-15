using System;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager theGame = new GameManager(6, 6);
            theGame.Run();

            WaitForUser();
        }

        private static void WaitForUser()
        {
            Console.WriteLine();
            Console.WriteLine("Hit any key to stop application");
            Console.ReadKey();
        }
    }
}
