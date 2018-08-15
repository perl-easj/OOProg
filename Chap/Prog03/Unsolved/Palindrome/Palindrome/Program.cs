using System;
using System.Collections.Generic;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            IPalindromeChecker checker = new PalindromeChecker();
            Dictionary<string, bool> testData = new Dictionary<string, bool>();

            testData.Add("rotor", true);
            testData.Add("motor", false);
            testData.Add("å", true);
            testData.Add("regninger", true);
            testData.Add("Regninger", true);
            testData.Add("", true);
            testData.Add("kat", false);
            testData.Add("En af dem der tit red med fane", true);

            foreach (var testItem in testData)
            {
                bool isPalindrome = checker.IsPalindrome(testItem.Key);
                bool testOK = isPalindrome == testItem.Value;
                string notText = isPalindrome ? "" : " not";

                if (testOK)
                {
                    Console.WriteLine($"\"{testItem.Key}\" is{notText} a palindrome (TEST OK)");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\"{testItem.Key}\" is{notText} a palindrome (TEST FAIL)");
                    Console.ResetColor();
                }
            }


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
