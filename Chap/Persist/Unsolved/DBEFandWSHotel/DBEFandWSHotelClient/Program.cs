using System;
using System.Collections.Generic;
using System.Linq;
using DBEFandWSHotelServer;

namespace DBEFandWSHotelClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for Web API calls...");
            Console.WriteLine("(App can be closed by pressing any key.)");
            Console.WriteLine();

            Run();

            Console.ReadKey();
        }

        private static void Run()
        {
            Console.WriteLine("Starting Web API test...");
            Console.WriteLine();

            const string serverURL = "http://localhost:1232";
            const string bookingURI = "Bookings";
            const string guestURI = "Guests";
            const string hotelURI = "Hotels";
            const string roomURI = "Rooms";

            const string apiPrefix = "api";

            throw new NotImplementedException("Uncomment the code below to test the Web Service");
            // Note that the Run method should also be changed to be "async"

            //WebAPIAsync<Booking> bookingWebApi = new WebAPIAsync<Booking>(serverURL, apiPrefix, bookingURI);
            //WebAPIAsync<Guest> guestWebApi = new WebAPIAsync<Guest>(serverURL, apiPrefix, guestURI);
            //WebAPIAsync<Hotel> hotelWebApi = new WebAPIAsync<Hotel>(serverURL, apiPrefix, hotelURI);
            //WebAPIAsync<Room> roomWebApi = new WebAPIAsync<Room>(serverURL, apiPrefix, roomURI);

            //WebAPITest<Booking> bookingWebAPITester = new WebAPITest<Booking>(bookingWebApi, "Booking");
            //WebAPITest<Guest> guestWebAPITester = new WebAPITest<Guest>(guestWebApi, "Guest");
            //WebAPITest<Hotel> hotelWebAPITester = new WebAPITest<Hotel>(hotelWebApi, "Hotel");
            //WebAPITest<Room> roomWebAPITester = new WebAPITest<Room>(roomWebApi, "Room");

            //await bookingWebAPITester.RunAPITestLoad();
            //await guestWebAPITester.RunAPITestLoad();
            //await hotelWebAPITester.RunAPITestLoad();
            //await roomWebAPITester.RunAPITestLoad();

            Console.WriteLine("Ended Web API test");
        }
    }
}
