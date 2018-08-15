using System;
using SupportManagement.Error;
using SupportManagement.SupportCommon;

namespace SupportManagement.SupportCoR.SupportHandler
{
    /// <summary>
    /// Support handler class, performing handling by using an
    /// aggregated implementation of ISupportAction
    /// </summary>
    public class SupportHandlerAggregation : SupportHandlerBase
    {
        #region Instance fields
        private ISupportAction _actualHandler;
        #endregion

        #region Constructor
        public SupportHandlerAggregation(ISupportAction actualHandler, ISupportHandler nextHandler = null) : base(nextHandler)
        {
            _actualHandler = actualHandler ?? throw new ArgumentException($"SupportHandlerAggregation constructor: Caller must supply an ISupport implementation");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Try to handle ticket by delegating to ISupport implementation.
        /// </summary>
        public override bool TryHandle(ErrorTicket ticket)
        {
            return _actualHandler.TryHandle(ticket);
        } 
        #endregion
    }
}