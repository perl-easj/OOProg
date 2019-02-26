using System;
using System.Collections.Generic;
using ASWCClassroomDay4.ExtensionLib;

namespace ASWCClassroomDay4
{
    public class ExtensionMethodTester
    {
        public static void Run()
        {
            Movie aMovie = new Movie("Alien", 106);

            Console.WriteLine();
            Console.WriteLine("Properties defined explicitly in class");
            Console.WriteLine(aMovie.Title);
            Console.WriteLine(aMovie.DurationInMins);

            Console.WriteLine();
            Console.WriteLine("Extension method, defined in MovieExtensions (in separate namespace)");
            Console.WriteLine($"{aMovie.DurationInHours():F2}");


            List<Movie> movies = new List<Movie>();
            movies.Add(aMovie);
            movies.Add(new Movie("Se7en", 112));
            movies.Add(new Movie("Inception", 148));
            ICatalog<Movie> movieCat = new Catalog<Movie>(movies);

            Console.WriteLine();
            Console.WriteLine("Extension method defined on interface type (a.k.a. MixIn).");
            Console.WriteLine(movieCat.HowMany());

            //IEnumerable<int> numbers = new List<int> { 14, 2, 39, 64 };

            //for (int i = 0; i < 20; i++)
            //{
            //    Console.WriteLine($"Sum of numbers is {numbers.Sum()}");
            //}
            //Console.WriteLine("Sum of numbers");
        }
    }
}