using SupportManagement.Error;

namespace SupportManagement.SupportCommon
{
    /// <summary>
    /// Interface for any class capable of trying to handle an error ticket.
    /// </summary>
    public interface ISupportAction
    {
        /// <summary>
        /// Return value will indicate if error ticket was actually handled.
        /// </summary>
        bool TryHandle(ErrorTicket ticket);
    }
}