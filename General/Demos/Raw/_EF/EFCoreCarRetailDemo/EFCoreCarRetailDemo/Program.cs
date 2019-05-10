using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCarRetailDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CarRetailDBContext())
            {
                Console.WriteLine("All records in Car table:");
                foreach (Car c in db.Cars)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
