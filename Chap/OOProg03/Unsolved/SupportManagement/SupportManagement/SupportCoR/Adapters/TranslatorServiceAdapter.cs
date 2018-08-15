using SupportManagement.Error;
using SupportManagement.SupportCoR.SupportHandler;
using SupportManagement.SupportOriginal;

namespace SupportManagement.SupportCoR.Adapters
{
    /// <summary>
    /// Class which adapts the translator service to the ISupportHandler 
    /// interface, by inheriting from SupportHandlerBase.
    /// A TranslatorServiceAdapter object can then participate in a 
    /// support handler CoR.
    /// </summary>
    public class TranslatorServiceAdapter : SupportHandlerBase
    {
        #region Instance fields
        private TranslatorService _translatorService;
        #endregion

        #region Constructor
        public TranslatorServiceAdapter(ISupportHandler nextHandler) : base(nextHandler)
        {
            _translatorService = new TranslatorService();
        }
        #endregion

        #region Methods
        public override void Handle(ErrorTicket ticket)
        {
            // Translate the incoming ticket, and forward it unconditionally.
            _translatorService.TranslateToEnglish(ticket);
            Forward(ticket);
        }

        // Not used, since we are overriding Handle
        public override bool TryHandle(ErrorTicket ticket)
        {
            return false;
        } 
        #endregion
    }
}