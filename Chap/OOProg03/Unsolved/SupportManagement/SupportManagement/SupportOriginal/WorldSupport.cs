using SupportManagement.Error;
using SupportManagement.SupportCommon;

namespace SupportManagement.SupportOriginal
{
    /// <summary>
    /// Class representing World support
    /// </summary>
    public class WorldSupport : SupportActionBase
    {
        public WorldSupport(ISupportCenter supportCenter) : base(supportCenter)
        {
        }

        /// <summary>
        /// World support must handle tickets with
        /// 1) Level: Catastrophic
        /// 2) English language
        /// </summary>
        public override bool CanHandle(ErrorTicket ticket)
        {
            return (ticket.Level == ErrorLevel.Catastrophic) && (ticket.Language == ErrorLanguage.English);
        }
    }
}