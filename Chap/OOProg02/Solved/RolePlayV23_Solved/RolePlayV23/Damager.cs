namespace RolePlayV23
{
    /// <summary>
    /// This class represents the Damager character type.
    /// </summary>
    public class Damager : Character
    {
        public Damager(string name, int hitPoints, int minDamage, int maxDamage) 
            : base(name, hitPoints, minDamage, maxDamage)
        {
        }

        /// <summary>
        /// A Damager has a 40 % chance of dealing increased damage.
        /// </summary>
        protected override int DealDamageModifyChance
        {
            get { return 40; }
        }

        /// <summary>
        /// If the damage is increased, it is doubled.
        /// </summary>
        protected override int CalculateModifiedDealDamage(int dealtDamage)
        {
            return dealtDamage * 2;
        }
    }
}
