using System;

namespace EFCoreMovie
{
    public class MovieDBTest
    {
        public static void PrintAllMovies()
        {
            Console.WriteLine("All movies currently in MovieDB database:");

            // Uncomment the below code after having generated classes
            //using (var db = new MovieDBContext())
            //{
            //    foreach (var item in db.Movies)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintAllStudios()
        {
            Console.WriteLine("All studios currently in MovieDB database:");

            // Uncomment the below code after having generated classes
            //using (var db = new MovieDBContext())
            //{
            //    foreach (var item in db.Studios)
            //    {
            //        Console.WriteLine(item);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void CreateMovies()
        {
            Console.WriteLine("Adding movies...");

            // Uncomment the below code after having generated classes
            //Movie m1 = new Movie { Id = 1001, Title = "AAA", Year = 2001, RunningTimeMins = 101, StudioId = 1 };
            //Movie m2 = new Movie { Id = 1002, Title = "BBB", Year = 2002, RunningTimeMins = 102, StudioId = 2 };
            //Movie m3 = new Movie { Id = 1003, Title = "CCC", Year = 2003, RunningTimeMins = 103, StudioId = 3 };
            //using (var db = new MovieDBContext())
            //{
            //    db.Movies.Add(m1);
            //    db.Movies.Add(m2);
            //    db.Movies.Add(m3);
            //    db.SaveChanges();
            //}

            Console.WriteLine();
        }

        public static void DeleteMovie(int id)
        {
            Console.WriteLine($"Deleting movie with id = {id}...");

            // Uncomment the below code after having generated classes
            //using (var db = new MovieDBContext())
            //{
            //    Movie m = db.Movies.Find(id);
            //    if (m != null)
            //    {
            //        db.Movies.Remove(m);
            //    }
            //    db.SaveChanges();
            //}

            Console.WriteLine();
        }

        public static void UpdateMovie(int id)
        {
            Console.WriteLine($"Updating movie with id = {id}...");

            // Uncomment the below code after having generated classes
            //using (var db = new MovieDBContext())
            //{
            //    Movie m = db.Movies.Find(id);
            //    if (m != null)
            //    {
            //        m.RunningTimeMins = 133;
            //        m.Title = "ABCDEF";
            //    }
            //    db.SaveChanges();
            //}

            Console.WriteLine();
        }
    }
}