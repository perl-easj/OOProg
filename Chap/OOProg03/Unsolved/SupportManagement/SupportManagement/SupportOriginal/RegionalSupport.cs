using SupportManagement.Error;
using SupportManagement.SupportCommon;

namespace SupportManagement.SupportOriginal
{
    /// <summary>
    /// Class representing Regional support
    /// </summary>
    public class RegionalSupport : SupportActionBase
    {
        public RegionalSupport(ISupportCenter supportCenter) : base(supportCenter)
        {
        }

        /// <summary>
        /// Regional support must handle tickets with
        /// 1) Level: Severe
        /// 2) English language
        /// </summary>
        public override bool CanHandle(ErrorTicket ticket)
        {
            return (ticket.Level == ErrorLevel.Severe) && (ticket.Language == ErrorLanguage.English);
        }
    }
}