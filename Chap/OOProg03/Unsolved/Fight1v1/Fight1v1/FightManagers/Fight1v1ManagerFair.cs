using System;

namespace Fight1v1
{
    /// <summary>
    /// This class implements a "fair" fighting management strategy.
    /// </summary>
    public class Fight1v1ManagerFair : Fight1v1Manager
    {
        #region Instance fields
        // You might need this :-)
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());
        #endregion

        #region Constructor
        public Fight1v1ManagerFair(Player playerA, Player playerB, int noOfFights)
            : base(playerA, playerB, noOfFights)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Each player has a 50 % chance of being the first to strike.
        /// </summary>
        protected override void ExchangeBlows(Player playerA, Player playerB)
        {
            // Implement ExchangeBlows according to the specification above.
        }
        #endregion
    }
}