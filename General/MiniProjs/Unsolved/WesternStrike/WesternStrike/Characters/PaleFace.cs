using System.Collections.Generic;
using WesternStrike.Combat;
using WesternStrike.Guns;
using WesternStrike.Knives;
using WesternStrike.Rifles;

namespace WesternStrike.Characters
{
    // PaleFaces have rifles, guns and knives.
    public class PaleFace
    {
        private string _name;
        private double _hitPoints;
        private Dictionary<string, double> _experticeMultiplier;

        private Krieghoff _rifle1;
        private Remington _rifle2;
        private Winchester _rifle3;

        private Colt _gun1;
        private RugerRevolver _gun2;
        private SmithWesson _gun3;

        private BowieKnife _knife1;
        private DundeeKnife _knife2;
        private GutterKnife _knife3;

        public PaleFace(
            string name, 
            double hitPoints, 
            Dictionary<string, double> experticeMultiplier,
            Krieghoff rifle1,
            Remington rifle2,
            Winchester rifle3,
            Colt gun1,
            RugerRevolver gun2,
            SmithWesson gun3,
            BowieKnife knife1,
            DundeeKnife knife2,
            GutterKnife knife3)
        {
            _name = name;
            _hitPoints = hitPoints;
            _experticeMultiplier = experticeMultiplier;

            _rifle1 = rifle1;
            _rifle2 = rifle2;
            _rifle3 = rifle3;

            _gun1 = gun1;
            _gun2 = gun2;
            _gun3 = gun3;

            _knife1 = knife1;
            _knife2 = knife2;
            _knife3 = knife3;
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

            if (weapon == 4 && _gun1 != null)
            {
                damage = _gun1.Damage * GetExperticeMultiplier("Colt");
                CombatLog.Save(Name + " dealt " + damage + " damage with a Colt gun");
            }

            if (weapon == 5 && _gun2 != null)
            {
                damage = _gun2.Damage * GetExperticeMultiplier("RugerRevolver");
                CombatLog.Save(Name + " dealt " + damage + " damage with a RugerRevolver gun");
            }

            if (weapon == 6 && _gun3 != null)
            {
                damage = _gun3.Damage * GetExperticeMultiplier("SmithWesson");
                CombatLog.Save(Name + " dealt " + damage + " damage with a SmithWesson gun");
            }

            if (weapon == 7 && _knife1 != null)
            {
                damage = _knife1.Damage * GetExperticeMultiplier("BowieKnife");
                CombatLog.Save(Name + " dealt " + damage + " damage with a BowieKnife knife");
            }

            if (weapon == 8 && _knife2 != null)
            {
                damage = _knife2.Damage * GetExperticeMultiplier("DundeeKnife");
                CombatLog.Save(Name + " dealt " + damage + " damage with a DundeeKnife knife");
            }

            if (weapon == 9 && _knife3 != null)
            {
                damage = _knife3.Damage * GetExperticeMultiplier("GutterKnife");
                CombatLog.Save(Name + " dealt " + damage + " damage with a GutterKnife knife");
            }
            return damage;
        }

        private double GetExperticeMultiplier(string weapon)
        {
            return _experticeMultiplier.ContainsKey(weapon) ? _experticeMultiplier[weapon] : 1.0;
        }
    }
}