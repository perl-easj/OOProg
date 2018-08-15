using SupportManagement.SupportCommon;
using SupportManagement.SupportCoR.Adapters;
using SupportManagement.SupportCoR.SupportHandler;
using SupportManagement.SupportOriginal;

namespace SupportManagement.SupportCoR.Config
{
    /// <summary>
    /// Default implementation if ISupportCoRConfiguration interface.
    /// Uses existing support classes for setting up support handlers.
    /// </summary>
    public class SupportCoRConfigurationDefault : ISupportCoRConfiguration
    {
        public ISupportHandler SetupSupportCoR(ISupportCenter supportCenter)
        {
            // Handler of otherwise unhandled tickets is at end of chain
            ISupportHandler supportHandler = new UnhandledTicketAdapter(supportCenter);

            // ...Add more support handlers here!

            return supportHandler;
        }
    }
}