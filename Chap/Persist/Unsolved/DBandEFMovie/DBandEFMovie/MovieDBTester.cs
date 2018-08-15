using System;

namespace DBandEFMovie
{
    public class MovieDBTester
    {
        public void PrintAllMovies()
        {
            throw new NotImplementedException("You should implement the PrintAllMovies method (and remove the throw statement :-))");
        }

        public void PrintAllStudios()
        {
            throw new NotImplementedException("You should implement the PrintAllStudios method (and remove the throw statement :-))");
        }

        public void CreateMovies()
        {
            throw new NotImplementedException("Please uncomment the method CreateMovies for testing (and remove the throw statement :-))");

            //Movie m1 = new Movie { Id = 1001, Title = "AAA", Year = 2001, RunningTimeInMins = 101, StudioId = 1 };
            //Movie m2 = new Movie { Id = 1002, Title = "BBB", Year = 2002, RunningTimeInMins = 102, StudioId = 2 };
            //Movie m3 = new Movie { Id = 1003, Title = "CCC", Year = 2003, RunningTimeInMins = 103, StudioId = 3 };

            //using (var db = new MovieDBContext())
            //{
            //    db.Movies.Add(m1);
            //    db.Movies.Add(m2);
            //    db.Movies.Add(m3);
            //    db.SaveChanges();
            //}
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException("Please uncomment the method DeleteMovie for testing (and remove the throw statement :-))");

            //using (var db = new MovieDBContext())
            //{
            //    Movie m = db.Movies.Find(id);
            //    if (m != null)
            //    {
            //        db.Movies.Remove(m);
            //    }
            //    db.SaveChanges();
            //}
        }

        public void UpdateMovies()
        {
            throw new NotImplementedException("Please uncomment the method UpdateMovies for testing (and remove the throw statement :-))");

            //using (var db = new MovieDBContext())
            //{
            //    Movie m = db.Movies.Find(1003);
            //    if (m != null)
            //    {
            //        m.RunningTimeInMins = 133;
            //        m.Title = "ABCDEF";
            //    }
            //    db.SaveChanges();
            //}
        }
    }
}