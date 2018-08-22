using System;
using BioDemo.Data.Base;
using BioDemo.Models.App;

namespace BioDemo.Data.Domain
{
    /// <summary>
    /// Class defining a "ticket", being defined as a single seat
    /// for a single show.
    /// A Ticket object will refer to a Show object through a key value;
    /// properties for converting the key value into a Ticket object
    /// reference (and through that find Movie and Theater objects as well)
    /// are also included.
    /// </summary>
    public class Ticket : DomainAppBase
    {
        #region Properties
        public int ShowKey { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }

        public Show ShowForTicket
        {
            get { return DomainModel.Instance.ShowCatalog.Read(ShowKey); }
        }

        public Movie MovieForTicket
        {
            get { return ShowForTicket?.MovieForShow; }
        }

        public Theater TheaterForTicket
        {
            get { return ShowForTicket?.TheaterForShow; }
        }

        public DateTime DateForTicket
        {
            get { return ShowForTicket?.DateForShow ?? DateTime.MinValue; }
        }

        public TimeSpan TimeForTicket
        {
            get { return ShowForTicket?.TimeForShow ?? TimeSpan.Zero; }
        }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            ShowKey = NullKey;
            Row = 1;
            Seat = 1;
        } 
        #endregion
    }
}