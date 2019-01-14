using System;

namespace TicketsToBoardingPasses
{
    /// <summary>
    /// This class represents a flight ticket. Note that most of the information
    /// in a ticket is found in the base class CommonInfo.
    /// </summary>
    public class Ticket : CommonInfo
    {
        #region Properties
        public Company CompanyAffiliation { get; }

        public int BonusPoints
        {
            get { return CompanyAffiliation?.BonusPoints ?? 0; }
        }

        private string CompanyAffiliationDescription
        {
            get { return CompanyAffiliation != null ? $" ({CompanyAffiliation.Name})" : ""; }
        }
        #endregion

        #region Constructor
        public Ticket(string passengerName, Company companyAffiliation, string flightNo, string fromWAC, string toWAC, DateTime timeOfDeparture)
            : base(passengerName, flightNo, fromWAC, toWAC, timeOfDeparture)
        {
            CompanyAffiliation = companyAffiliation;
        } 
        #endregion

        public override string ToString()
        {
            string startText = $"Ticket for {PassengerName}{CompanyAffiliationDescription}".PadRight(40);
            return $"{startText} : {base.ToString()}";
        }
    }
}