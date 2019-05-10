using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ01
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqTest lq = new LinqTest();
            Console.WriteLine($"Buffed by {lq.UseLINQ():F1} %");

            Console.ReadKey();
        }
    }
}
