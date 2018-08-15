using System;
using System.Collections.Generic;
using WesternStrike.Combat;
using WesternStrike.Weapons.Base;
using WesternStrike.Weapons.Types;

namespace WesternStrike.Inventory.Base
{
    public class Inventory
    {
        #region Instance fields
        private List<Weapon> _weapons;
        private Dictionary<WeaponType, int> _weaponLimits;
        #endregion

        #region Constructor
        public Inventory(Dictionary<WeaponType, int> weaponLimits)
        {
            _weapons = new List<Weapon>();
            _weaponLimits = weaponLimits;
        }
        #endregion

        #region Public properties
        public int Count
        {
            get { return _weapons.Count; }
        }
        #endregion

        #region Weapon Access methods (public)
        public Weapon GetWeapon(int weaponIndex)
        {
            if (weaponIndex >= _weapons.Count)
            {
                throw new ArgumentException("Index exceeds number of weapons");
            }

            return _weapons[weaponIndex];
        }

        public Weapon GetRandomWeapon()
        {
            return Count > 0 ? _weapons[NumberGenerator.Next(0, Count - 1)] : null;
        }

        public void AddWeapon(Weapon w)
        {
            _weapons.Add(w);
            if (!WeaponLimitOK())
            {
                throw new ArgumentException("Weapon limit exceeded!");
            }
        }
        #endregion

        #region Weapon Limitation methods (private)
        private bool WeaponLimitOK()
        {
            foreach (var wLimit in _weaponLimits)
            {
                if (WeaponLimit(wLimit.Key) < WeaponTypeCount[wLimit.Key])
                {
                    return false;
                }
            }
            return true;
        }

        private Dictionary<WeaponType, int> WeaponTypeCount
        {
            get
            {
                Dictionary<WeaponType, int> weaponTypeCount = new Dictionary<WeaponType, int>();

                foreach (var wType in Enum.GetValues(typeof(WeaponType)))
                {
                    weaponTypeCount.Add((WeaponType)wType, 0);
                }

                foreach (var weapon in _weapons)
                {
                    weaponTypeCount[weapon.Type]++;
                }

                return weaponTypeCount;
            }
        }

        private int WeaponLimit(WeaponType wType)
        {
            return _weaponLimits.ContainsKey(wType) ? _weaponLimits[wType] : 0;
        } 
        #endregion
    }
}