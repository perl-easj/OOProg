namespace Fight1v1
{
    /// <summary>
    /// This class implements a fighting management strategy
    /// biased towards player A (player A has an advantage).
    /// </summary>
    public class Fight1v1ManagerBiasedA : Fight1v1Manager
    {
        #region Constructor
        public Fight1v1ManagerBiasedA(Player playerA, Player playerB, int noOfFights)
            : base(playerA, playerB, noOfFights)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Player A always strikes first.
        /// </summary>
        protected override void ExchangeBlows(Player playerA, Player playerB)
        {
            Player playerFirst = PlayerA;
            Player playerSecond = PlayerB;

            playerSecond.ReceiveDamage(playerFirst.DealDamage());
            if (!playerSecond.Dead)
            {
                playerFirst.ReceiveDamage(playerSecond.DealDamage());
            }
        } 
        #endregion
    }
}