using SupportManagement.Error;
using SupportManagement.SupportCommon;

namespace SupportManagement.SupportOriginal
{
    /// <summary>
    /// Class representing National support
    /// </summary>
    public class NationalSupport : SupportActionBase
    {
        public NationalSupport(ISupportCenter supportCenter) : base(supportCenter)
        {
        }

        /// <summary>
        /// National support must handle tickets with
        /// 1) Level: Moderate
        /// 2) Any language
        /// </summary>
        public override bool CanHandle(ErrorTicket ticket)
        {
            return ticket.Level == ErrorLevel.Moderate;
        }
    }
}