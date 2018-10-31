using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Game aGame = new Game();
            aGame.Run();

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
