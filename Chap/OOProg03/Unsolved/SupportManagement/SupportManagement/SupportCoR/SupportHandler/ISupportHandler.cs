using SupportManagement.Error;

namespace SupportManagement.SupportCoR.SupportHandler
{
    /// <summary>
    /// Interface for a support handler. A support handler is
    /// different from a support action, since its Handle method
    /// is always presumed successful (does not return a value).
    /// Success may however be achieved by forwarding a ticket.
    /// </summary>
    public interface ISupportHandler
    {
        /// <summary>
        /// Handle the ticket. Is per definition always successful.
        /// </summary>
        void Handle(ErrorTicket ticket);

        /// <summary>
        /// Return whether or not ticket can be forwarded to
        /// a new handler down the CoR. 
        /// </summary>
        bool CanForward(ErrorTicket ticket);

        /// <summary>
        /// Forward the ticket to a new handler down the CoR. 
        /// </summary>
        void Forward(ErrorTicket ticket);

        /// <summary>
        /// Defines the response to an unhandled ticket.
        /// </summary>
        void UnhandledAction(ErrorTicket ticket);
    }
}