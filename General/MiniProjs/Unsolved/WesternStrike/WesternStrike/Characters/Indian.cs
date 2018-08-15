using System.Collections.Generic;
using WesternStrike.Axes;
using WesternStrike.Bows;
using WesternStrike.Combat;
using WesternStrike.Rifles;

namespace WesternStrike.Characters
{
    // Indians have rifles, bows and axes
    public class Indian
    {
        private string _name;
        private double _hitPoints;
        private Dictionary<string, double> _experticeMultiplier;

        private Krieghoff _rifle1;
        private Remington _rifle2;
        private Winchester _rifle3;

        private JuniorBow _bow1;
        private LongBow _bow2;
        private StrikerBow _bow3;

        private Damascus _axe1;
        private DoubleAxe _axe2;
        private Tomahawk _axe3;

        public Indian(
            string name,
            double hitPoints,
            Dictionary<string, double> experticeMultiplier,
            Krieghoff rifle1,
            Remington rifle2,
            Winchester rifle3,
            JuniorBow bow1,
            LongBow bow2,
            StrikerBow bow3,
            Damascus axe1,
            DoubleAxe axe2,
            Tomahawk axe3)
        {
            _name = name;
            _hitPoints = hitPoints;
            _experticeMultiplier = experticeMultiplier;

            _rifle1 = rifle1;
            _rifle2 = rifle2;
            _rifle3 = rifle3;

            _bow1 = bow1;
            _bow2 = bow2;
            _bow3 = bow3;

            _axe1 = axe1;
            _axe2 = axe2;
            _axe3 = axe3;
        }

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

        public void ReceiveDamage(double damagePoints)
        {
            if (damagePoints > 0)
            {
                _hitPoints = _hitPoints - damagePoints;
                string message = Name + " receives " + damagePoints + " damage, and is down to " + _hitPoints + " hit points";
                CombatLog.Save(message);

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
            // Select weapon
            double damage = 0.0;
            int weapon = NumberGenerator.Next(1, 9);

            if (weapon == 1 && _rifle1 != null)
            {
                damage = _rifle1.Damage * GetExperticeMultiplier("Krieghoff");
                CombatLog.Save(Name + " dealt " + damage + " damage with a Krieghoff rifle");
            }

            if (weapon == 2 && _rifle2 != null)
            {
                damage = _rifle2.Damage * GetExperticeMultiplier("Remington");
                CombatLog.Save(Name + " dealt " + damage + " damage with a Remington rifle");
            }

            if (weapon == 3 && _rifle3 != null)
            {
                damage = _rifle3.Damage * GetExperticeMultiplier("Winchester");
                CombatLog.Save(Name + " dealt " + damage + " damage with a Winchester rifle");
            }

            if (weapon == 4 && _bow1 != null)
            {
                damage = _bow1.Damage * GetExperticeMultiplier("JuniorBow");
                CombatLog.Save(Name + " dealt " + damage + " damage with a JuniorBow bow");
            }

            if (weapon == 5 && _bow2 != null)
            {
                damage = _bow2.Damage * GetExperticeMultiplier("LongBow");
                CombatLog.Save(Name + " dealt " + damage + " damage with a LongBow bow");
            }

            if (weapon == 6 && _bow3 != null)
            {
                damage = _bow3.Damage * GetExperticeMultiplier("StrikerBow");
                CombatLog.Save(Name + " dealt " + damage + " damage with a StrikerBow bow");
            }

            if (weapon == 7 && _axe1 != null)
            {
                damage = _axe1.Damage * GetExperticeMultiplier("Damascus");
                CombatLog.Save(Name + " dealt " + damage + " damage with a Damascus axe");
            }

            if (weapon == 8 && _axe2 != null)
            {
                damage = _axe2.Damage * GetExperticeMultiplier("DoubleAxe");
                CombatLog.Save(Name + " dealt " + damage + " damage with a DoubleAxe axe");
            }

            if (weapon == 9 && _axe3 != null)
            {
                damage = _axe3.Damage * GetExperticeMultiplier("Tomahawk");
                CombatLog.Save(Name + " dealt " + damage + " damage with a Tomahawk axe");
            }

            return damage;
        }

        private double GetExperticeMultiplier(string weapon)
        {
            return _experticeMultiplier.ContainsKey(weapon) ? _experticeMultiplier[weapon] : 1.0;
        }
    }
}