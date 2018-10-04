using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Printing content of all tables, first attempt 
            //using (var db = new HotelDBContext())
            //{
            //    PrintItems(db.Hotels);
            //    PrintItems(db.Rooms);
            //    PrintItems(db.Guests);
            //    PrintItems(db.Bookings);
            //}

            // Printing content of all tables, second attempt 
            //using (var db = new HotelDBContext())
            //{
            //    PrintItems(db.Hotels.Include(item => item.Rooms));
            //    PrintItems(db.Rooms.Include(item => item.Bookings));
            //    PrintItems(db.Guests.Include(item => item.Bookings));
            //    PrintItems(db.Bookings);
            //}

            KeepConsoleWindowOpen();
        }

        private static void PrintItems<T>(IEnumerable<T> items)
        {
            Console.WriteLine($"All {typeof(T).Name} rows in database:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine("Done, press any key to close application...");
            Console.ReadKey();
        }
    }
}
