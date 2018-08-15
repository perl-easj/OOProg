using SupportManagement.Error;
using SupportManagement.SupportCommon;
using SupportManagement.SupportCoR.SupportHandler;

namespace SupportManagement.SupportCoR.Adapters
{
    /// <summary>
    /// Class for handling otherwise unhandled tickets. An object of 
    /// this class should be at the end of a support handler CoR.
    /// </summary>
    public class UnhandledTicketAdapter : SupportActionBase, ISupportHandler
    {
        #region Constructor
        public UnhandledTicketAdapter(ISupportCenter supportCenter) : base(supportCenter)
        {
        }
        #endregion

        #region Methods
        public override bool CanHandle(ErrorTicket ticket)
        {
            return true;
        }

        public void Handle(ErrorTicket ticket)
        {
            _supportCenter.UnhandledTickets.Add(ticket);
        }

        public bool CanForward(ErrorTicket ticket)
        {
            return false;
        }

        public void Forward(ErrorTicket ticket)
        {
            // Intentionally blank, cannot happen
        }

        public void UnhandledAction(ErrorTicket ticket)
        {
            // Intentionally blank, cannot happen
        } 
        #endregion
    }
}