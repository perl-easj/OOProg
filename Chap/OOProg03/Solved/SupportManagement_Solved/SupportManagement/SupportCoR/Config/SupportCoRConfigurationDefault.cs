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

            // Before that comes World support
            supportHandler = new SupportHandlerAggregation(new WorldSupport(supportCenter), supportHandler);

            // Before that comes Regional support
            supportHandler = new SupportHandlerAggregation(new RegionalSupport(supportCenter), supportHandler);

            // Before that comes (adapted) translation service
            supportHandler = new TranslatorServiceAdapter(supportHandler);

            // Before that comes National support
            supportHandler = new SupportHandlerAggregation(new NationalSupport(supportCenter), supportHandler);

            // Starting point is Local support
            supportHandler = new SupportHandlerAggregation(new LocalSupport(supportCenter), supportHandler);

            return supportHandler;
        }
    }
}