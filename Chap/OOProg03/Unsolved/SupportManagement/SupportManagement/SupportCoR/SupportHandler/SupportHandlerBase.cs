using System;
using SupportManagement.Error;

namespace SupportManagement.SupportCoR.SupportHandler
{
    /// <summary>
    /// Base class for support handler classes. The specific strategy for
    /// error ticket handling must be implemented in a derived class.
    /// </summary>
    public abstract class SupportHandlerBase : ISupportHandler
    {
        #region Instance fields
        private ISupportHandler _nextHandler;
        #endregion

        #region Constructor
        protected SupportHandlerBase(ISupportHandler nextHandler = null)
        {
            _nextHandler = nextHandler;
        }
        #endregion

        #region Methods
        /// <summary>
        /// General algorithm for how a support handler class
        /// handles an error ticket.
        /// </summary>
        public virtual void Handle(ErrorTicket ticket)
        {
            // First try to handle the ticket, by calling (abstract) TryHandle
            if (!TryHandle(ticket))
            {
                // TryHandle failed, try to forward ticket
                if (CanForward(ticket))
                {
                    Forward(ticket);
                }
                else
                {
                    UnhandledAction(ticket);
                }
            }
        }

        /// <summary>
        /// Ticket can be forwarded if another handler
        /// is available down the CoR.
        /// </summary>
        public bool CanForward(ErrorTicket ticket)
        {
            return _nextHandler != null;
        }

        /// <summary>
        /// Forward the ticket down the CoR
        /// </summary>
        public void Forward(ErrorTicket ticket)
        {
            _nextHandler?.Handle(ticket);
        }

        /// <summary>
        /// Specific algorithms for trying to handle a ticket
        /// must be defined in derived classes.
        /// </summary>
        public abstract bool TryHandle(ErrorTicket ticket);

        /// <summary>
        /// Defines response to not being able to handle the ticket.
        /// Can be overrided in derived classes. 
        /// </summary>
        public virtual void UnhandledAction(ErrorTicket ticket)
        {
            throw new ArgumentException($"SupportHandlerBase::Handle -> Could not handle ticket: {ticket}");
        } 
        #endregion
    }
}