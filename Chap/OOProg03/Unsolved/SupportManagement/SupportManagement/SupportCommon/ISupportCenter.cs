using System.Collections.Generic;
using SupportManagement.Error;

namespace SupportManagement.SupportCommon
{
    /// <summary>
    /// Interface for a "support center", which may handle a set of error tickets.
    /// An error ticket can be:
    ///   Open: Submitted, but not handled yet.
    ///   Closed: Handled and solved.
    ///   Unhandled: Could not be handled, even though an attempt was made.
    /// </summary>
    public interface ISupportCenter
    {
        /// <summary>
        /// Number of open error tickets.
        /// </summary>
        int OpenTicketCount { get; }

        /// <summary>
        /// Number of closed error tickets.
        /// </summary>
        int ClosedTicketCount { get; }

        /// <summary>
        /// Number of unhandled error tickets.
        /// </summary>
        int UnhandledTicketCount { get; }

        /// <summary>
        /// List of open error tickets.
        /// </summary>
        List<ErrorTicket> OpenTickets { get; }

        /// <summary>
        /// List of closed error tickets.
        /// </summary>
        List<ErrorTicket> ClosedTickets { get; }

        /// <summary>
        /// List of unhandled error tickets.
        /// </summary>
        List<ErrorTicket> UnhandledTickets { get; }

        /// <summary>
        /// Clear all tickets from all lists.
        /// </summary>
        void Reset();

        /// <summary>
        /// Submit a single error ticket, which will be placed 
        /// in the list of Open tickets.
        /// </summary>
        void SubmitTicket(ErrorTicket ticket);

        /// <summary>
        /// Try to handle all open tickets. After calling this method, it should hold that:
        /// 1) No tickets are in the Open list
        /// 2) Tickets successfully handled are in the Closed list
        /// 3) Tickets unsuccessfully handled are in the Unhandled list
        /// </summary>
        void HandleOpenTickets();
    }
}