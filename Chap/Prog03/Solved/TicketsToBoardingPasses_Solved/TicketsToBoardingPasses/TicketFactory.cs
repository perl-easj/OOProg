using System;

namespace TicketsToBoardingPasses
{
    /// <summary>
    /// The TicketFactory class is just a convenience class, making it easier to
    /// produce many tickets for the same flight.
    /// </summary>
    public class TicketFactory
    {
        #region Instance field and Constructor
        private CommonInfo _commonInfo;

        public TicketFactory()
        {
            _commonInfo = null;
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Sets up the common information for a flight. Once set, the tickets which
        /// are subsequently generated will use this common information.
        /// </summary>
        public void SetCommonInfo(string flightNo, string fromWAC, string toWAC, DateTime timeOfDeparture)
        {
            _commonInfo = new CommonInfo("(empty)", flightNo, fromWAC, toWAC, timeOfDeparture);
        }

        /// <summary>
        /// Creates a ticket for an individual passenger.
        /// </summary>
        public Ticket Create(string passengerName, Company company = null)
        {
            return new Ticket(passengerName, company, _commonInfo.FlightNo, _commonInfo.FromWAC, _commonInfo.ToWAC, _commonInfo.TimeOfDeparture);
        } 
        #endregion
    }
}