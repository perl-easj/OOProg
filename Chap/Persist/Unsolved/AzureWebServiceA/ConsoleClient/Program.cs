using System;
using System.Collections.Generic;

// ReSharper disable UnusedParameter.Local

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverURL = "http://WRITETHENAMEOFYOUROWNWEBSERVICEHERE.azurewebsites.net";
            // string serverURL = "https://demoaserver20180315.azurewebsites.net"; // Use in case of emergency :-)

            TestAPI<Car>(serverURL, "Cars");
            TestAPI<Customer>(serverURL, "Customers");
            TestAPI<Employee>(serverURL, "Employees");
            TestAPI<Sale>(serverURL, "Sales");

            Console.ReadKey();
        }

        static async void TestAPI<T>(string serverURL, string apiID)
        {
            WebAPISource<T> source = new WebAPISource<T>(serverURL, apiID);

            Console.WriteLine($"Testing API {apiID}, loading from source...");
            List<T> objects = await source.Load();

            Console.WriteLine($"Got {apiID} data:");
            foreach (var obj in objects)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
