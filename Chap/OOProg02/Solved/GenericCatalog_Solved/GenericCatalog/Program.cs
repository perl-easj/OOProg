using System;

namespace GenericCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog<string, Car> cars = new Catalog<string, Car>();
            Car c1 = new Car("AB 12 345", 80000);
            Car c2 = new Car("CD 34 456", 65000);
            Car c3 = new Car("EF 56 567", 28000);
            cars.Insert(c1.LicensePlate, c1);
            cars.Insert(c2.LicensePlate, c2);
            cars.Insert(c3.LicensePlate, c3);

            Catalog<string, Employee> employees = new Catalog<string, Employee>();
            Employee e1 = new Employee("Allan", 1962);
            Employee e2 = new Employee("Bente", 1975);
            employees.Insert(c1.LicensePlate, e1);
            employees.Insert(c2.LicensePlate, e2);

            Catalog<string, Computer> computers = new Catalog<string, Computer>();
            Computer co1 = new Computer("XN001", "Server");
            Computer co2 = new Computer("XN002", "Backup");
            Computer co3 = new Computer("XN005", "Gateway");
            Computer co4 = new Computer("XN008", "Extra backup");
            computers.Insert(co1.NetworkName, co1);
            computers.Insert(co2.NetworkName, co2);
            computers.Insert(co3.NetworkName, co3);
            computers.Insert(co4.NetworkName, co4);

            Catalog<int, Phone> phones = new Catalog<int, Phone>();
            Phone p1 = new Phone(12345678, "Samsung");
            Phone p2 = new Phone(23456789, "LG");
            Phone p3 = new Phone(34567890, "Huawei");
            Phone p4 = new Phone(87654321, "LG");
            Phone p5 = new Phone(76543210, "Apple");
            phones.Insert(p1.Number, p1);
            phones.Insert(p2.Number, p2);
            phones.Insert(p3.Number, p3);
            phones.Insert(p4.Number, p4);
            phones.Insert(p5.Number, p5);

            cars.PrintAll();
            employees.PrintAll();
            computers.PrintAll();
            phones.PrintAll();

            Console.WriteLine($"We have {cars.Count} cars");
            Console.WriteLine($"We have {employees.Count} employees");
            Console.WriteLine($"We have {computers.Count} computers");
            Console.WriteLine($"We have {phones.Count} phones");

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
