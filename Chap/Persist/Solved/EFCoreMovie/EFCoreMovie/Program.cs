using System;

namespace EFCoreMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reading movies and studios
            MovieDBTest.PrintAllMovies();
            MovieDBTest.PrintAllStudios();

            // Creating movies
            MovieDBTest.CreateMovies();
            MovieDBTest.PrintAllMovies();

            // Updating movie
            MovieDBTest.UpdateMovie(1003);
            MovieDBTest.PrintAllMovies();

            // Deleting movies
            MovieDBTest.DeleteMovie(1001);
            MovieDBTest.DeleteMovie(1002);
            MovieDBTest.DeleteMovie(1003);
            MovieDBTest.PrintAllMovies();

            Console.WriteLine("Done, press any key to close application...");
            Console.ReadKey();
        }
    }
}
