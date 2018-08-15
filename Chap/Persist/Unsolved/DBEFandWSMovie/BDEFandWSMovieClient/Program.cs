using System;
using DBEFandWSMovieServer;
// ReSharper disable UnusedParameter.Local

namespace BDEFandWSMovieClient
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

            const string serverURL = "http://localhost:9025";
            const string movieURI = "Movies";
            const string studioURI = "Studios";
            const string apiPrefix = "api";

            throw new NotImplementedException("Uncomment the code below to test the Web Service");
            // Note that the Run method should also be changed to be "async"


            //WebAPIAsync<Movie> movieWebApi = new WebAPIAsync<Movie>(serverURL, apiPrefix, movieURI);
            //WebAPIAsync<Studio> studioWebApi = new WebAPIAsync<Studio>(serverURL, apiPrefix, studioURI);

            //WebAPITest<Movie> movieWebAPITester = new WebAPITest<Movie>(movieWebApi, "Movie");
            //WebAPITest<Studio> studioWebAPITester = new WebAPITest<Studio>(studioWebApi, "Studio");

            //await movieWebAPITester.RunAPITestLoad();
            //await studioWebAPITester.RunAPITestLoad();

            //await movieWebAPITester.RunAPITestCreate(new Movie {Id = 1001, Title = "Twister", Year = 2001, RunningTimeInMins = 101, StudioId = 1 });
            //await studioWebAPITester.RunAPITestCreate(new Studio {Id = 101, Name = "Twisted Movies", HQCity = "Detroit", NoOfEmployees = 400 });

            //await movieWebAPITester.RunAPITestRead(5);
            //await studioWebAPITester.RunAPITestRead(2);

            //await movieWebAPITester.RunAPITestUpdate(1001, new Movie {Id = 1001, Title = "UPDATED Twister", Year = 2001, RunningTimeInMins = 101, StudioId = 1});
            //await studioWebAPITester.RunAPITestUpdate(101, new Studio {Id = 101, Name = "UPDATED Twisted Movies", HQCity = "Detroit", NoOfEmployees = 400});

            //await movieWebAPITester.RunAPITestDelete(1001);
            //await studioWebAPITester.RunAPITestDelete(101);

            Console.WriteLine("Ended Web API test");
        }
    }
}
