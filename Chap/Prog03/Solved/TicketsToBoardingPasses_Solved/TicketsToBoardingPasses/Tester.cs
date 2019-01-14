using System;
using System.Collections.Generic;

namespace TicketsToBoardingPasses
{
    public class Tester
    {
        public void Run()
        {
            // Create companies
            Company ambu = new Company("Ambu", 25000);
            Company bavarian = new Company("Bavarian Nordic", 15000);
            Company carlsberg = new Company("Carlsberg", 32000);
            Company dsv = new Company("DSV", 38000);

            // Create Airport System
            AirportSystem airportSystem = new AirportSystem();

            // Set up Ticket factory
            DateTime departureCPHVIE = new DateTime(2019, 1, 18, 10, 45, 00);
            TicketFactory ticketFactory = new TicketFactory();
            ticketFactory.SetCommonInfo("SAS1337", "CPH", "VIE", departureCPHVIE);

            // Create actual tickets
            List<Ticket> tickets = new List<Ticket>();
            tickets.Add(ticketFactory.Create("Allan", dsv));
            tickets.Add(ticketFactory.Create("Beatrice"));
            tickets.Add(ticketFactory.Create("Casper", bavarian));
            tickets.Add(ticketFactory.Create("David", dsv));
            tickets.Add(ticketFactory.Create("Earl", ambu));
            tickets.Add(ticketFactory.Create("Gretchen", carlsberg));
            tickets.Add(ticketFactory.Create("Henry", ambu));
            tickets.Add(ticketFactory.Create("Ivar"));
            tickets.Add(ticketFactory.Create("Jonathan", carlsberg));
            tickets.Add(ticketFactory.Create("Karl", ambu));

            // Print all tickets
            PrintCollection<Ticket>("tickets", tickets);

            // Create Boarding passes
            List<BoardingPass> boardingPasses = airportSystem.GenerateBoardingPasses(tickets);

            // Print all boarding passes
            PrintCollection<BoardingPass>("boarding passes", boardingPasses);
        }

        private void PrintCollection<T>(string header, List<T> items)
        {
            Console.WriteLine($"All {header}:");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}