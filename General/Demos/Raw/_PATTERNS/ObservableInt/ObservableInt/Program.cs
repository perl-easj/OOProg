using System;
using System.Collections.Generic;

namespace ObservableInt
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectTest();

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static void DirectTest()
        {
            ObsInt a = new ObsInt();
            Console.WriteLine($"a is {a.Value}");

            a.Value = 3;
            Console.WriteLine($"a is {a.Value}");

            ObserverA obsA = new ObserverA();
            ObserverB obsB = new ObserverB();

            a.ValueChanged += obsA.MethodA;
            a.ValueChanged += obsB.MethodB;

            a.Value = 5;
            Console.WriteLine($"a is {a.Value}");

            ObsInt b = new ObsInt(6);
            b.ValueChanged += obsB.MethodB;
            b.Value = 8;

            ObsInt c = a + b;
            Console.WriteLine($"c is {c.Value}");

            int d = c;
            Console.WriteLine($"d is {d}");

            ObsInt e = b * c;
            Console.WriteLine($"e is {e.Value}");

            List<ObsInt> obsIntList = new List<ObsInt>();
            ObsInt sum = obsIntList.Total();
            Console.WriteLine($"sum is {sum}");
        }
    }
}
