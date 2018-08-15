using System;

namespace CrossTalk
{
    class Program
    {
        static void Main(string[] args)
        {
            Reciter.ReciteAllTheWords();

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
