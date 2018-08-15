using System;
using System.Collections.Generic;
using WesternStrike.Weapons.Types.Axes;
using WesternStrike.Weapons.Types.Bows;
using WesternStrike.Weapons.Types.Guns;
using WesternStrike.Weapons.Types.Knives;
using WesternStrike.Weapons.Types.Rifles;

namespace WesternStrike.Weapons
{
    public class WeaponsDB
    {
        #region Singleton
        private static WeaponsDB _instance;

        public static WeaponsDB Data
        {
            get { return _instance ?? (_instance = new WeaponsDB()); }
        }
        #endregion

        #region Instance fields
        private Dictionary<string, int> _baseDamage;
        private Dictionary<string, int> _maxAdditionalDamage;
        #endregion

        #region Constructor
        private WeaponsDB()
        {
            _baseDamage = new Dictionary<string, int>();
            _maxAdditionalDamage = new Dictionary<string, int>();
            Populate();
        }
        #endregion

        #region Data Access methods (public)
        public int BaseDamage(string id)
        {
            if (!_baseDamage.ContainsKey(id))
            {
                throw new ArgumentException($"Unknown weapon id {id}");
            }

            return _baseDamage[id];
        }

        public int MaxAdditionalDamage(string id)
        {
            if (!_maxAdditionalDamage.ContainsKey(id))
            {
                throw new ArgumentException($"Unknown weapon id {id}");
            }

            return _maxAdditionalDamage[id];
        }
        #endregion

        #region Data population methods (private)
        private void Populate()
        {
            AddEntry(Axe.Damascus, 10, 10);
            AddEntry(Axe.DoubleAxe, 15, 10);
            AddEntry(Axe.Tomahawk, 10, 20);

            AddEntry(Bow.Junior, 15, 5);
            AddEntry(Bow.Long, 25, 10);
            AddEntry(Bow.Striker, 20, 30);

            AddEntry(Gun.Colt, 40, 30);
            AddEntry(Gun.Ruger, 25, 15);
            AddEntry(Gun.SmithWesson, 35, 25);

            AddEntry(Knife.Bowie, 10, 15);
            AddEntry(Knife.Dundee, 25, 10);
            AddEntry(Knife.Gutter, 15, 5);

            AddEntry(Rifle.Krieghoff, 70, 30);
            AddEntry(Rifle.Remington, 50, 20);
            AddEntry(Rifle.Winchester, 60, 25);
        }

        private void AddEntry(string id, int baseDamage, int maxAdditionalDamage)
        {
            _baseDamage.Add(id, baseDamage);
            _maxAdditionalDamage.Add(id, maxAdditionalDamage);
        } 
        #endregion
    }
}