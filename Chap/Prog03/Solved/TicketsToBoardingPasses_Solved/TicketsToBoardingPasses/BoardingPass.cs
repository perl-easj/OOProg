using System;

namespace TicketsToBoardingPasses
{
    /// <summary>
    /// This class represents a boarding pass. For simplicity, it is assumed that
    /// passengers don't get a specific seat, but are given a "seat area" specification
    /// (e.g. "economy" or "business"), and can then take any seat in that area.
    /// </summary>
    public class BoardingPass : CommonInfo
    {
        #region Properties
        public string Gate { get; }
        public SeatAreaType SeatArea { get; set; }
        public int BonusPoints { get; }
        #endregion

        #region Constructors
        public BoardingPass(
            string passengerName,
            int bonusPoints,
            string flightNo,
            string fromWAC,
            string toWAC,
            DateTime timeOfDeparture,
            string gate,
            SeatAreaType seatArea)
                : base(passengerName, flightNo, fromWAC, toWAC, timeOfDeparture)
        {
            Gate = gate;
            SeatArea = seatArea;
            BonusPoints = bonusPoints;
        }

        public BoardingPass(
            CommonInfo commonInfo,
            int bonusPoints,
            string gate,
            SeatAreaType seatArea)
                : this(commonInfo.PassengerName, bonusPoints, commonInfo.FlightNo, commonInfo.FromWAC, commonInfo.ToWAC, commonInfo.TimeOfDeparture, gate, seatArea)
        {
        } 
        #endregion

        public override string ToString()
        {
            string startText = $"Boarding Pass for {PassengerName} (seated in {SeatArea})".PadRight(50);
            return $"{startText} : {base.ToString()}";
        }
    }
}