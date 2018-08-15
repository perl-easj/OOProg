using System;

namespace DBandEFMovie
{
    public class MovieDBTester
    {
        public void PrintAllMovies()
        {
            using (var db = new MovieDBContext())
            {
                Console.WriteLine("All Movie records in database:");
                foreach (Movie m in db.Movies)
                {
                    Console.WriteLine(m);
                }
                Console.WriteLine();
            }
        }

        public void PrintAllStudios()
        {
            using (var db = new MovieDBContext())
            {
                Console.WriteLine("All Studio records in database:");
                foreach (Studio s in db.Studios)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
        }

        public void CreateMovies()
        {
            Movie m1 = new Movie { Id = 1001, Title = "AAA", Year = 2001, RunningTimeInMins = 101, StudioId = 1 };
            Movie m2 = new Movie { Id = 1002, Title = "BBB", Year = 2002, RunningTimeInMins = 102, StudioId = 2 };
            Movie m3 = new Movie { Id = 1003, Title = "CCC", Year = 2003, RunningTimeInMins = 103, StudioId = 3 };

            using (var db = new MovieDBContext())
            {
                db.Movies.Add(m1);
                db.Movies.Add(m2);
                db.Movies.Add(m3);
                db.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            using (var db = new MovieDBContext())
            {
                Movie m = db.Movies.Find(id);
                if (m != null)
                {
                    db.Movies.Remove(m);
                }
                db.SaveChanges();
            }
        }

        public void UpdateMovies()
        {
            using (var db = new MovieDBContext())
            {
                Movie m = db.Movies.Find(1003);
                if (m != null)
                {
                    m.RunningTimeInMins = 133;
                    m.Title = "ABCDEF";
                }
                db.SaveChanges();
            }
        }
    }
}