using System;

namespace ASWCClassroomDay4
{
    public class AnonTypesTester
    {
        public static void Run()
        {
            Car aCar = new Car("AB 12 345", 80000);
            var obj = new { aCar.LicensePlate, IsCheap = (aCar.Price < 100000) };

            Console.WriteLine();
            Console.WriteLine("Printing object of anonymous type...");
            Console.WriteLine($"obj = {obj.LicensePlate} {obj.IsCheap}");

            //MethodA_v1(aCar);
            //MethodA_v2(aCar);
            //MethodB_v1(aCar);
            //MethodB_v2(aCar);
            //MethodB_v3(aCar);

            //MethodA_v1(obj);
            //MethodA_v2(obj);
            //MethodB_v1(obj);
            //MethodB_v2(obj);
            //MethodB_v3(obj);
        }

        private static void MethodA_v1(object obj)
        {
            Console.WriteLine(obj);
        }

        private static void MethodA_v2(object obj)
        {
            Console.WriteLine(((Car)obj).LicensePlate);
        }

        private static void MethodB_v1(dynamic obj)
        {
            Console.WriteLine(obj);
        }

        private static void MethodB_v2(dynamic obj)
        {
            Console.WriteLine(obj.LicensePlate);
        }

        private static void MethodB_v3(dynamic obj)
        {
            Console.WriteLine(obj.WooHooLetsParty);
        }
    }
}