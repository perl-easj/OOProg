using SupportManagement.Error;

namespace SupportManagement.SupportOriginal
{
    /// <summary>
    /// This class simulates a translation service, 
    /// which can translate an error ticket to 
    /// another language (currently only English).
    /// </summary>
    public class TranslatorService
    {
        /// <summary>
        /// Simulate a translation to English.
        /// </summary>
        public void TranslateToEnglish(ErrorTicket ticket)
        {
            ticket.Language = ErrorLanguage.English;
        }
    }
}