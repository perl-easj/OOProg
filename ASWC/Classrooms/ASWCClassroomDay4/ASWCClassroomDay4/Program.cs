using System;

//using ASWCClassroomDay4.TimeLib;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute

namespace ASWCClassroomDay4
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtensionMethodTester.Run();
            AnonTypesTester.Run();
            ReflectionTester.Run();

            Console.WriteLine();
            Console.WriteLine("Done...");
            Console.ReadKey();
        }


    }
}
