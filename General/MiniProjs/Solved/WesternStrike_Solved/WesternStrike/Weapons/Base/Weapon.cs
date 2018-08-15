using WesternStrike.Combat;
using WesternStrike.Weapons.Types;

namespace WesternStrike.Weapons.Base
{
    public class Weapon
    {
        #region Instance fields
        private WeaponType _type;
        private string _id;
        private int _baseDamage;
        private int _maxAdditionalDamage;
        #endregion

        #region Constructor
        public Weapon(WeaponType type, string id, int baseDamage, int maxAdditionalDamage)
        {
            _type = type;
            _id = id;
            _baseDamage = baseDamage;
            _maxAdditionalDamage = maxAdditionalDamage;
        }
        #endregion

        #region Properties
        public double Damage
        {
            get { return _baseDamage + NumberGenerator.Next(0, _maxAdditionalDamage) + EnhancementDamage; }
        }

        public WeaponType Type
        {
            get { return _type; }
        }

        public string ID
        {
            get { return _id; }
        }

        public int BaseDamage
        {
            get { return _baseDamage; }
        }

        public int MaxAdditionalDamage
        {
            get { return _maxAdditionalDamage; }
        }

        public virtual int EnhancementDamage
        {
            get { return 0; }
        }
        #endregion
    }
}