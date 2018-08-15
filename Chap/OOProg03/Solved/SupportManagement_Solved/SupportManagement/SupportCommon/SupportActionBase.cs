using SupportManagement.Error;

namespace SupportManagement.SupportCommon
{
    /// <summary>
    /// Base class for support classes, All support classes
    /// need to refer to a Support Center (by interface).
    /// </summary>
    public abstract class SupportActionBase : ISupportAction
    {
        #region Instance fields
        protected ISupportCenter _supportCenter;
        #endregion

        #region Constructor
        protected SupportActionBase(ISupportCenter supportCenter)
        {
            _supportCenter = supportCenter;
        }
        #endregion

        #region Methods
        /// <summary>
        /// General algorithm for trying to handle a single error ticket.
        /// If a ticket can be handled, it is set to Solved, and placed
        /// in the list of Closed error tickets.
        /// </summary>
        public bool TryHandle(ErrorTicket ticket)
        {
            bool canHandle = CanHandle(ticket);

            if (canHandle)
            {
                ticket.Level = ErrorLevel.Solved;
                _supportCenter.ClosedTickets.Add(ticket);
            }

            return canHandle;
        }

        /// <summary>
        /// Specific support classes need to define specific
        /// criteria for being able to handle an error ticket.
        /// </summary>
        public abstract bool CanHandle(ErrorTicket ticket); 
        #endregion
    }
}