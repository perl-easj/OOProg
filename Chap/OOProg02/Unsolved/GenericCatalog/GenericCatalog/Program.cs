using System;

namespace GenericCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            CarCatalog cars = new CarCatalog();
            Car c1 = new Car("AB 12 345", 80000);
            Car c2 = new Car("CD 34 456", 65000);
            Car c3 = new Car("EF 56 567", 28000);
            cars.Insert(c1.LicensePlate, c1);
            cars.Insert(c2.LicensePlate, c2);
            cars.Insert(c3.LicensePlate, c3);

            EmployeeCatalog employees = new EmployeeCatalog();
            Employee e1 = new Employee("Allan", 1962);
            Employee e2 = new Employee("Bente", 1975);
            Employee e3 = new Employee("Carlo", 1973);
            employees.Insert(c1.LicensePlate, e1);
            employees.Insert(c2.LicensePlate, e2);
            employees.Insert(c3.LicensePlate, e3);

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
