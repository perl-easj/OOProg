using System;

namespace EFClient01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieContext())
            {
                foreach (var studio in db.Studios)
                {
                    Console.WriteLine(studio);
                }
                Console.WriteLine();

                //Movie m = new Movie();
                //m.Title = "Alene Hjemme";
                //m.Year = 1990;
                //m.RunningTimeInMins = 105;
                //m.StudioId = 3;

                //db.Movies.Add(m);
                //db.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
