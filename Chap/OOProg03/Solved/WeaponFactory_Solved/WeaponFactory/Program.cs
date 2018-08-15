using System;
// ReSharper disable UnusedParameter.Local

namespace WeaponFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Run environment generator test 
            WeaponFactoryTest.Run();

            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
