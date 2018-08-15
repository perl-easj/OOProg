using System;
using SupportManagement.Error;
using SupportManagement.SupportCommon;
using SupportManagement.SupportCoR.Config;
using SupportManagement.SupportCoR.SupportHandler;

namespace SupportManagement.SupportCoR
{
    /// <summary>
    /// Implementation of Support Center functionality, 
    /// containing a reference to a support handler CoR.
    /// </summary>
    public class SupportCenterCoR : SupportCenterBase
    {
        #region Instance fields
        private ISupportHandler _handler;
        private ISupportCoRConfiguration _configurator;
        #endregion

        #region Constructor
        public SupportCenterCoR(ISupportCoRConfiguration configurator)
        {
            _configurator = configurator;
            _handler = _configurator?.SetupSupportCoR(this);
        }
        #endregion

        #region Methods
        public override void TryHandleTicket(ErrorTicket ticket)
        {
            if (_handler == null)
            {
                throw new ArgumentException("SupportCenterCoR::TryHandleTicket -> Handler not set!");
            }

            _handler.Handle(ticket);
        } 
        #endregion
    }
}