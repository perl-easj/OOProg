using System.Collections.Generic;
using WesternStrike.Combat;
using WesternStrike.Weapons;
using WesternStrike.Weapons.Base;

namespace WesternStrike.Characters.Base
{
    public class Character
    {
        #region Instance fields
        private string _name;
        private double _hitPoints;
        private Inventory.Base.Inventory _weapons;
        private Dictionary<string, double> _experticeMultiplier;
        #endregion

        #region Constructor
        public Character(
            string name,
            double hitPoints,
            Inventory.Base.Inventory weapons,
            Dictionary<string, double> experticeMultiplier)
        {
            _name = name;
            _hitPoints = hitPoints;
            _weapons = weapons;
            _experticeMultiplier = experticeMultiplier;
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public double HitPoints
        {
            get { return _hitPoints; }
        }

        public bool Dead
        {
            get { return (_hitPoints <= 0); }
        }
        #endregion

        #region Damage methods (public)
        public void ReceiveDamage(double damagePoints)
        {
            if (damagePoints > 0)
            {
                _hitPoints = _hitPoints - damagePoints;
                CombatLog.Save($"{Name} receives {damagePoints:F2} damage, and is down to {_hitPoints:F2} hit points");

                if (Dead)
                {
                    CombatLog.Save("");
                    CombatLog.Save(Name + " died!");
                    CombatLog.Save("");
                }
            }
        }

        public double DealDamage()
        {
            double damage = 0.0;
            Weapon w = _weapons.GetRandomWeapon();

            if (w != null)
            {
                damage = w.Damage * GetExperticeMultiplier(w.ID);
                CombatLog.Save($"{Name} dealt {damage:F2} damage with a {w.ID} {w.Type}");
            }

            return damage;
        }
        #endregion

        #region Private helper methods
        private double GetExperticeMultiplier(string weapon)
        {
            return _experticeMultiplier.ContainsKey(weapon) ? _experticeMultiplier[weapon] : 1.0;
        } 
        #endregion
    }
}