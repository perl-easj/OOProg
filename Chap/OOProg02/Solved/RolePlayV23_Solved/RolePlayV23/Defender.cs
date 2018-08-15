namespace RolePlayV23
{
    /// <summary>
    /// This class represents the Defender character type.
    /// </summary>
    public class Defender : Character
    {
        public Defender(string name, int hitPoints, int minDamage, int maxDamage) 
            : base(name, hitPoints, minDamage, maxDamage)
        {
        }

        /// <summary>
        /// A Defender has a 45 % chance of having the received damage reduced.
        /// </summary>
        protected override int ReceiveDamageModifyChance
        {
            get { return 45; }
        }

        /// <summary>
        /// If the damage is reduced, it is reduced by 50 %.
        /// </summary>
        protected override int CalculateModifiedReceivedDamage(int receivedDamage)
        {
            return receivedDamage / 2;
        }
    }
}
