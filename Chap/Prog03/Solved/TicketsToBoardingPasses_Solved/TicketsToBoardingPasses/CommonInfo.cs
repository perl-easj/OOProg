using System;

namespace TicketsToBoardingPasses
{
    /// <summary>
    /// This class holds the information which is "shared" between a Ticket and
    /// a BoardingPass. Both these classes then inherit from CommonInfo.
    /// Note that WAC means World Airport Code, e.g. "CPH" for Copenhagen.
    /// </summary>
    public class CommonInfo
    {
        #region Properties
        public string PassengerName { get; }
        public string FlightNo { get; }
        public string FromWAC { get; }
        public string ToWAC { get; }
        public DateTime TimeOfDeparture { get; }
        #endregion

        #region Constructor
        public CommonInfo(string passengerName, string flightNo, string fromWAC, string toWAC, DateTime timeOfDeparture)
        {
            PassengerName = passengerName;
            FlightNo = flightNo;
            FromWAC = fromWAC;
            ToWAC = toWAC;
            TimeOfDeparture = timeOfDeparture;
        } 
        #endregion

        public override string ToString()
        {
            return $"Flight {FlightNo} [{FromWAC}-{ToWAC}], at {TimeOfDeparture.ToShortTimeString()}, {TimeOfDeparture.ToShortDateString()}";
        }
    }
}