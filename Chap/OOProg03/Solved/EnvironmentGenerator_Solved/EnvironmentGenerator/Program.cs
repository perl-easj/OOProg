using System;

namespace EnvironmentGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run environment generator test 
            EnvironmentGeneratorTest.Run();

            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
