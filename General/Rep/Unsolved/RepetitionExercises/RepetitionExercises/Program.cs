using System;

namespace RepetitionExercises
{
    class Program
    {
        static void Main(string[] args)
        {

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
