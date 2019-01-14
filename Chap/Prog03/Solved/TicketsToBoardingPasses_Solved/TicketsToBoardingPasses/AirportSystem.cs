using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedParameter.Local

namespace TicketsToBoardingPasses
{
    /// <summary>
    /// This class models a (very simple) Airport Management System.
    /// For now, it only handles generation of boarding passes from tickets.
    /// </summary>
    public class AirportSystem
    {
        /// <summary>
        /// This is the central method, which transforms a list of tickets
        /// into a list of boarding passes.
        /// This functionality has been implemented using LINQ.
        /// </summary>
        public List<BoardingPass> GenerateBoardingPasses(List<Ticket> tickets)
        {
            // Sanity check of parameters
            if (tickets == null || tickets.Count == 0)
            {
                throw new ArgumentException("GenerateBoardingPasses called with null or zero tickets");
            }

            // Find cutoff and gate, simple by calling helper methods
            double cutOff = CalculateUpgradeCutoff(tickets);
            string gate = LookupGateForFlight(tickets.First().FlightNo);

            // Generate BoardingPass objects from Ticket objects by using Select.
            // For each Ticket object, a corresponding BoardingPass object is "selected",
            // using both specific information from Ticket, and general information like gate number.
            List<BoardingPass> boardingPasses = tickets.Select(t => new BoardingPass(
                    t, 
                    t.BonusPoints, 
                    gate, 
                    t.BonusPoints > cutOff ? SeatAreaType.Business : SeatAreaType.Economy))
                .ToList();

            return boardingPasses;
        }

        /// <summary>
        /// This method contains an algorithm for calculating the "cutoff" w.r.t.
        /// whether or not a boarding pass can be upgraded to a "business class" seat.
        /// You do NOT need to change this method.
        /// </summary>
        private double CalculateUpgradeCutoff(List<Ticket> tickets)
        {
            List<int> bonusPointsList = tickets.Select(t => t.BonusPoints).ToList();
            double cutOff = (bonusPointsList.Average() + ((bonusPointsList.Max() - bonusPointsList.Average()) / 4));
            return cutOff;
        }

        /// <summary>
        /// This method is intended to return the boarding gate for a given flight.
        /// For now, it just returns a dummy value.
        /// You do NOT need to change this method.
        /// </summary>
        private string LookupGateForFlight(string flightNo)
        {
            return "A23";
        }
    }
}