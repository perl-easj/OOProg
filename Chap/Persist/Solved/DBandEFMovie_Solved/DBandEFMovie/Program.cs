using System;

namespace DBandEFMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieDBTester dbTest = new MovieDBTester();
            dbTest.PrintAllMovies();
            dbTest.PrintAllStudios();

            Console.WriteLine("Creating movies...");
            dbTest.CreateMovies();
            dbTest.PrintAllMovies();

            Console.WriteLine("Deleting a movie...");
            dbTest.DeleteMovie(1002);
            dbTest.PrintAllMovies();

            Console.WriteLine("Updating a movie...");
            dbTest.UpdateMovies();
            dbTest.PrintAllMovies();


            Console.WriteLine("Done, press any key to close application...");
            Console.ReadKey();
        }
    }
}
