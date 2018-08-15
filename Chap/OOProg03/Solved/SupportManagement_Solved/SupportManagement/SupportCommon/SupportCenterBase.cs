using System.Collections.Generic;
using SupportManagement.Error;

namespace SupportManagement.SupportCommon
{
    /// <summary>
    /// Base class for all Support Center classes.
    /// </summary>
    public abstract class SupportCenterBase : ISupportCenter
    {
        #region Instance fields
        private List<ErrorTicket> _openTickets;
        private List<ErrorTicket> _closedTickets;
        private List<ErrorTicket> _unhandledTickets;
        #endregion

        #region Constructor
        protected SupportCenterBase()
        {
            _openTickets = new List<ErrorTicket>();
            _closedTickets = new List<ErrorTicket>();
            _unhandledTickets = new List<ErrorTicket>();
        }
        #endregion

        #region Properties
        public int OpenTicketCount
        {
            get { return _openTickets.Count; }
        }

        public int ClosedTicketCount
        {
            get { return _closedTickets.Count; }
        }

        public int UnhandledTicketCount
        {
            get { return _unhandledTickets.Count; }
        }

        public List<ErrorTicket> OpenTickets
        {
            get { return _openTickets; }
        }

        public List<ErrorTicket> ClosedTickets
        {
            get { return _closedTickets; }
        }

        public List<ErrorTicket> UnhandledTickets
        {
            get { return _unhandledTickets; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Clear all tickets from all lists.
        /// </summary>
        public void Reset()
        {
            _openTickets.Clear();
            _closedTickets.Clear();
            _unhandledTickets.Clear();
        }

        /// <summary>
        /// Submit a single error ticket, which will be placed 
        /// in the list of Open tickets.
        /// </summary>
        public void SubmitTicket(ErrorTicket ticket)
        {
            _openTickets.Add(ticket);
        }

        /// <summary>
        /// Try to handle all open tickets. After calling this method, it should hold that:
        /// 1) No tickets are in the Open list
        /// 2) Tickets successfully handled are in the Closed list
        /// 3) Tickets unsuccessfully handled are in the Unhandled list
        /// </summary>
        public void HandleOpenTickets()
        {
            while (OpenTicketCount > 0)
            {
                // Take a ticket from the list
                ErrorTicket ticket = OpenTickets[OpenTicketCount - 1];
                OpenTickets.RemoveAt(OpenTicketCount - 1);

                // Try to handle it
                TryHandleTicket(ticket);
            }
        }

        /// <summary>
        /// Specific Support Center classes need to define a specific
        /// algorithm for how to handle an error ticket.
        /// </summary>
        public abstract void TryHandleTicket(ErrorTicket ticket); 
        #endregion
    }
}