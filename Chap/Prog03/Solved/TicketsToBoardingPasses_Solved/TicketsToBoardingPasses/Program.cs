using System;

namespace TicketsToBoardingPasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester theTester = new Tester();
            theTester.Run();

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
