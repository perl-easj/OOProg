using System;
using CryptoCrownLib;

// ReSharper disable UnusedParameter.Local

namespace CryptoCrowns
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = GetUserInput();
            Console.Clear();

            IMiner myMiner = userInput == "s" ? 
                (IMiner) new MinerSequential("Per") : 
                         new MinerWithTasks("Per");

            myMiner.MineCryptoCrowns(50);
            myMiner.OnFinished();

            KeepConsoleWindowOpen();
        }

        private static string GetUserInput()
        {
            Console.WriteLine("Hit s for Sequential mining, t for Task-based mining");
            string userInput = "";

            while (userInput != "s" && userInput != "t")
            {
                userInput = Console.ReadKey(true).KeyChar.ToString();
            }

            return userInput;
        }

        static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
