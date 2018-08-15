using System;

namespace Fight1v1
{
    /// <summary>
    /// This class implements a "fair" fighting management strategy.
    /// </summary>
    public class Fight1v1ManagerFair : Fight1v1Manager
    {
        #region Instance fields
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
            int percent = _generator.Next(0, 100) + 1;

            Player playerFirst = percent > 50 ? PlayerA : PlayerB;
            Player playerSecond = percent > 50 ? PlayerB : PlayerA;

            playerSecond.ReceiveDamage(playerFirst.DealDamage());
            if (!playerSecond.Dead)
            {
                playerFirst.ReceiveDamage(playerSecond.DealDamage());
            }
        } 
        #endregion
    }
}