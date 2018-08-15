using System;

namespace DBandEFHotel
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new HotelDBContext())
            {
                Console.WriteLine("All Hotel records in database:");
                foreach (Hotel h in db.Hotels)
                {
                    Console.WriteLine(h);
                }
                Console.WriteLine();

                Console.WriteLine("All Room records in database:");
                foreach (Room r in db.Rooms)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();

                Console.WriteLine("All Guest records in database:");
                foreach (Guest g in db.Guests)
                {
                    Console.WriteLine(g);
                }
                Console.WriteLine();

                Console.WriteLine("All Booking records in database:");
                foreach (Booking b in db.Bookings)
                {
                    Console.WriteLine(b);
                }
                Console.WriteLine();

            }

            Console.WriteLine("Done, press any key to close application...");
            Console.ReadKey();
        }
    }
}
