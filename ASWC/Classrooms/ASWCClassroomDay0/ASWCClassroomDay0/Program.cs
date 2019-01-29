using System;
using System.Collections.Generic;
using System.Linq;
using ASWCClassroomDay0.FunctionTypes;
using ASWCClassroomDay0.Generics;
using ASWCClassroomDay0.Inheritance;
using ASWCClassroomDay0.LINQ;

namespace ASWCClassroomDay0
{
    class Program
    {
        static void Main(string[] args)
        {
            TestInheritance();
            TestGenerics();
            TestFunctionTypes();
            TestLINQ();

            Wait();
        }

        private static void TestInheritance()
        {
            Dog aDog = new Dog(4, true);

            Console.WriteLine(aDog.Age);
            Console.WriteLine(aDog.CanHunt);


            Animal a1 = new Animal(3);
            a1.Sound();

            Dog d1 = new Dog(6, false);
            d1.Sound();

            Animal a2 = new Dog(8, false);
            a2.Sound();


            List<Animal> zoo = new List<Animal>();
            zoo.Add(new Cat(12));
            zoo.Add(new Cat(12));
            zoo.Add(new Dog(2, false));
            zoo.Add(new Dog(5, true));
            zoo.Add(new Cat(12));

            foreach (var anAnimal in zoo)
            {
                anAnimal.Sound();
            }
        }

        private static void TestGenerics()
        {
            Catalog<Order> orderCatalog = new Catalog<Order>();
            Catalog<Customer> customerCatalog = new Catalog<Customer>();

            orderCatalog.Create(new Order("Order #1", 1));
            orderCatalog.Create(new Order("Order #2", 2));

            customerCatalog.Create(new Customer("Allan", 1));
            customerCatalog.Create(new Customer("Betty", 2));

            // orderCatalog.Create(new Customer("Carl", 3));
            //customerCatalog.Create(new Order("Orer #3", 3));
        }

        private static void TestFunctionTypes()
        {
            List<int> numbers = new List<int> { 12, 43, 17, 8, 5 };


            List<int> resV1 = Filterer.FilterValuesV1(numbers);

            List<int> resV2 = Filterer.FilterValuesV2(numbers, new FilterOdd());

            List<int> resV3 = Filterer.FilterValuesV3(numbers, v => v < 20);

            Func<int, bool> condFunc = v => v % 2 == 0;
            List<int> resV3A = Filterer.FilterValuesV3(numbers, condFunc);
        }

        private static void TestLINQ()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("Alien", 1979, 112, "Fox"));
            movies.Add(new Movie("Inception", 2010, 143, "Not Fox"));
            movies.Add(new Movie("Arrival", 2018, 131, "Fox"));

            var query01 = from m in movies
                          select m.Title;

            var query02 = from m in movies
                          select new { m.Title, m.Year };

            var query03 = from m in movies
                          where m.Year < 1996
                          select new { m.Title, m.Year };

            var query04 = from m in movies
                          select m.DurationInMins;
            double averageDuration = query04.Average();


            List<int> numbers = new List<int> { 12, 37, 8, 17 };
            var query11 = numbers.Where(i => i < 15);

            var query12 = movies
                         .Select(m => new { m.Title, m.Year })
                         .Where(m => m.Year > 1995);

            var query13 = movies
                         .Select(m => new { m.Title, m.Year })
                         .Where(m => m.Year < 2010)
                         .Where(m => m.Year > 1995);
        }

        private static void Wait()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
