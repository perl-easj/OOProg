using System;

// ReSharper disable UnusedParameter.Local

namespace SupportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportCenterTest.Run();

            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
