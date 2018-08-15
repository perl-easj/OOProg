using SupportManagement.Error;
using SupportManagement.SupportCommon;

namespace SupportManagement.SupportOriginal
{
    /// <summary>
    /// Implementation of Support Center functionality, 
    /// containing an explicit algorithm for trying to 
    /// handle an error ticket.
    /// </summary>
    public class SupportCenterOriginal : SupportCenterBase
    {
        #region Instance fields
        private ISupportAction _localSupport;
        private ISupportAction _nationalSupport;
        private ISupportAction _regionalSupport;
        private ISupportAction _worldSupport;
        private TranslatorService _translatorService;
        #endregion

        #region Constructor
        public SupportCenterOriginal()
        {
            _localSupport = new LocalSupport(this);
            _nationalSupport = new NationalSupport(this);
            _regionalSupport = new RegionalSupport(this);
            _worldSupport = new WorldSupport(this);
            _translatorService = new TranslatorService();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Explicit algorithm for trying to handle an error ticket.
        /// </summary>
        public override void TryHandleTicket(ErrorTicket ticket)
        {
            bool handled = false;

            // 1) Try local support
            if (!handled)
            {
                handled = _localSupport.TryHandle(ticket);
            }

            // 2) Try national support
            if (!handled)
            {
                handled = _nationalSupport.TryHandle(ticket);
            }

            // 3) Try regional support (must translate ticket to English first)
            if (!handled)
            {
                _translatorService.TranslateToEnglish(ticket);
                handled = _regionalSupport.TryHandle(ticket);
            }

            // 4) Try world support (ticket has already been translated)
            if (!handled)
            {
                handled = _worldSupport.TryHandle(ticket);
            }

            // 5) If all else fails, add to unhandled ticket list
            if (!handled)
            {
                UnhandledTickets.Add(ticket);
            }
        } 
        #endregion
    }
}