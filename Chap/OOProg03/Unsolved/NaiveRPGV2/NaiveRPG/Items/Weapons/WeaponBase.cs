using NaiveRPG.Helpers;

namespace NaiveRPG.Items.Weapons
{
    /// <summary>
    /// Base class for all items considered to be weapons.
    /// </summary>
    public abstract class WeaponBase : ItemBase
    {
        private double _maxDamage;

        protected WeaponBase(double maxDamage)
        {
            _maxDamage = maxDamage;
        }

        public virtual double Damage
        {
            get { return RNG.RandomDouble(0.0, _maxDamage); }
        }      
    }
}