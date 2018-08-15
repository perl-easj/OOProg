namespace WeaponShopV20
{
    /// <summary>
    /// This class represents a Wand. An Wand is 
    /// considered to be a weapon.
    /// </summary>
    public class Wand : Weapon
    {
        public const int InitialWandMinDamage = 10;
        public const int InitialWandMaxDamage = 30;

        #region Instance fields
        private bool _isEnchanted;
        #endregion

        #region Constructor
        public Wand(string description) : base(description, InitialWandMinDamage, InitialWandMaxDamage)
        {
            _isEnchanted = false;
        }
        #endregion

        #region Properties
        public bool IsEnchanted
        {
            get { return _isEnchanted; }
            set { _isEnchanted = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns the damage dealt by the Wand. The damage
        /// is doubled if the wand is enchanted.
        /// </summary>
        public override int DealDamage()
        {
            return base.DealDamage() * (IsEnchanted ? 2 : 1);
        } 
        #endregion
    }
}