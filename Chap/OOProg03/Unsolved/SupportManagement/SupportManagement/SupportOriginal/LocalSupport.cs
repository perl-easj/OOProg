using SupportManagement.Error;
using SupportManagement.SupportCommon;

namespace SupportManagement.SupportOriginal
{
    /// <summary>
    /// Class representing Local support
    /// </summary>
    public class LocalSupport : SupportActionBase
    {
        public LocalSupport(ISupportCenter supportCenter) : base(supportCenter)
        {
        }

        /// <summary>
        /// Local support must handle tickets with
        /// 1) Level: Light
        /// 2) Any language
        /// </summary>
        public override bool CanHandle(ErrorTicket ticket)
        {
            return ticket.Level == ErrorLevel.Light;
        }
    }
}