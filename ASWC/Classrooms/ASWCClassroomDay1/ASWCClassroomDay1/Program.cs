using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASWCClassroomDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();


            #region Simple transformation

            var qr1 = movies.Select(m => m.Title);

            var qr2 = movies.Where(m => m.Year > 1995).Select(m => m.Title);

            var qr3 = movies.Select(m => new { m.Title, m.Year });

            #endregion


            #region Full transformation

            List<MovieInfo> miList1 = movies
                .Select(m => new MovieInfo(
                    m.Title,
                    m.Year - 1900,
                    m.DurationInMins / 60.0))
                .ToList();

            List<MovieInfo> miList2 = Transformer.TransformItems<Movie, MovieInfo>(
                movies, m => new MovieInfo(
                    m.Title,
                    m.Year - 1900,
                    m.DurationInMins / 60.0));

            #endregion


            #region Collection transformation / Actions

            Dictionary<string, Movie> movieDict = movies.ToDictionary(m => m.Title);

            foreach (Movie m in movies)
            {
                Console.WriteLine(m);
            }

            // movies.Select(m => Console.WriteLine(m));

            movies.ForEach(m => Console.WriteLine(m));
            movies.ForEach(Console.WriteLine);

            movies
                .Select(m => $"{m.Title}, made in {m.Year}")
                .ToList()
                .ForEach(Console.WriteLine);

            #endregion


            #region Home-rolled Aggregation

            List<int> numbers = new List<int> { 21, 8, 14, 45 };
            int sum = numbers.Sum();

            ProductCalculator prodCalc = new ProductCalculator();
            Console.WriteLine($"Product is {prodCalc.Aggregate(numbers)}");

            int product = AggregateCalculator<int, int>.Aggregate(
                numbers,
                () => 1,
                (val, item) => val * item);
            Console.WriteLine($"Product is {product}");

            List<string> words = new List<string> { "This ", "is ", "Sparta!" };
            string concatStr = AggregateCalculator<string, string>.Aggregate(
                words,
                () => "",
                (val, item) => val + item);
            Console.WriteLine(concatStr);

            int sosA = AggregateCalculator<int, int>.Aggregate(
                numbers,
                () => 0,
                (val, item) => val + (item * item));
            Console.WriteLine($"[Home-rolled Aggregate] Sum-of-squares is {sosA}");

            #endregion


            #region LINQ Aggregate

            int sosB = numbers.Aggregate(
                (val, item) => val + (item * item)); // Accumulator function
            Console.WriteLine($"[LINQ Aggregate(1)] Sum-of-squares is {sosB}");

            int sosC = numbers.Aggregate(
                0, // Seed value
                (val, item) => val + (item * item)); // Accumulator function
            Console.WriteLine($"[LINQ Aggregate(2)] Sum-of-squares is {sosC}");

            double sosAverage = numbers.Aggregate(
                0, // Seed value
                (val, item) => val + (item * item), // Accumulator function
                val => (val * 1.0) / numbers.Count); // Result selector function
            Console.WriteLine($"[LINQ Aggregate(3)] Sum-of-squares average is {sosAverage}"); 

            #endregion


            Wait();
        }

        private static void Wait()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close...");
            Console.ReadKey();
        }
    }
}
