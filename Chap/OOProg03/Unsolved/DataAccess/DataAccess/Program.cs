using System;

// ReSharper disable UnusedParameter.Local

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run the Data Access test
            DataAccessTest.Run();

            Console.WriteLine("Press any key to close application.");
            Console.ReadKey();
        }
    }
}
