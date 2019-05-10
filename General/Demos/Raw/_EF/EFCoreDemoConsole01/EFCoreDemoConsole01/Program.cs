using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemoConsole01
{
    class Program
    {
        static void Main(string[] args)
        {
            CarRetailDBContext dbContext = new CarRetailDBContext();

            DbSet<Car> cars = dbContext.Cars;

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
