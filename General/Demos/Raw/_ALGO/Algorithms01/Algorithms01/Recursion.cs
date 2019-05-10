using System;

namespace Algorithms01
{
    public class Recursion
    {
        public void PrintHello(int numberOfCallsLeft)
        {
            if (numberOfCallsLeft > 0)
            {
                Console.WriteLine("Hello");
                PrintHello(numberOfCallsLeft - 1);
            }
        }

        public int Factorial(int n)
        {
            return (n <= 1) ? 1 : (n * Factorial(n - 1));
        }

        public void TowersOfHanoi(string pegA, string pegB, string pegC, int n)
        {
            if (n > 0)
            {
                TowersOfHanoi(pegA, pegC, pegB, n - 1);
                Console.WriteLine("Move disk " + n + " : " + pegA + " -> " + pegC);
                TowersOfHanoi(pegB, pegA, pegC, n - 1);
            }
        }

        public int Fibonacci(int n)
        {
            return (n < 3) ? 1 : (Fibonacci(n - 1) + Fibonacci(n - 2));
        }
    }
}