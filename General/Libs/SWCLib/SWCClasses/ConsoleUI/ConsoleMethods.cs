using System;

namespace SWCClasses.ConsoleUI
{
    public class ConsoleMethods
    {
        public static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }

        public static void WriteLineAt(string msg, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(msg);
        }

        private static string GetUserInputSingleChar(string allowedChars, string userPrompt)
        {
            Console.WriteLine(userPrompt);
            string userInput = "---INITVALUE---";

            while (!allowedChars.Contains(userInput))
            {
                userInput = Console.ReadKey(true).KeyChar.ToString();
            }

            return userInput;
        }
    }
}