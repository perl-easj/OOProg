using System.Collections.Generic;
using System.Linq;
using NaiveRPG.GameManagement;
using NaiveRPG.Helpers;
using NaiveRPG.Interfaces;

namespace NaiveRPG.Participants
{
    public abstract class ParticipantBase : IParticipant
    {
        #region Instance fields
        private int _maxInitialHealthPoints;
        private int _maxInitialGold;
        private int _maxInitialArmor;
        private int _maxInitialWeapons;
        private double _meleeMaxDamage;
        #endregion

        #region Properties
        public virtual string Name { get; }
        public double HealthPoints { get; private set; }
        public int GoldOwned { get; set; }
        public List<IArmor> ArmorOwned { get; }
        public List<IWeapon> WeaponsOwned { get; }

        public bool Dead
        {
            get { return HealthPoints <= 0; }
        }

        public double ArmorPoints
        {
            get { return ArmorOwned.Count == 0 ? 0 : ArmorOwned.Select(a => a.ArmorPoints).Average(); }
        }
        #endregion

        #region Constructor
        protected ParticipantBase(
            string name,
            int maxInitialHealthPoints,
            int maxInitialGold,
            int maxInitialArmor,
            int maxInitialWeapons,
            double meleeMaxDamage)
        {
            Name = name;

            _maxInitialHealthPoints = maxInitialHealthPoints;
            _maxInitialGold = maxInitialGold;
            _maxInitialArmor = maxInitialArmor;
            _maxInitialWeapons = maxInitialWeapons;
            _meleeMaxDamage = meleeMaxDamage;

            HealthPoints = SetInitialHealthPoints();
            GoldOwned = SetInitialGoldOwned();
            ArmorOwned = SetInitialArmorOwned();
            WeaponsOwned = SetInitialWeaponsOwned();
        }
        #endregion

        #region Methods
        protected virtual double SetInitialHealthPoints()
        {
            return RNG.RandomDouble(1.0, _maxInitialHealthPoints);
        }

        protected virtual int SetInitialGoldOwned()
        {
            return RNG.RandomInt(0, _maxInitialGold);
        }

        protected virtual List<IArmor> SetInitialArmorOwned()
        {
            List<IArmor> initialArmor = new List<IArmor>();
            for (int i = 0; i < RNG.RandomInt(0, _maxInitialArmor); i++)
            {
                initialArmor.Add(GameFactory.Instance().ArmorFactory.CreateArmor());
            }
            return initialArmor;
        }

        protected virtual List<IWeapon> SetInitialWeaponsOwned()
        {
            List<IWeapon> initialWeapons = new List<IWeapon>();
            for (int i = 0; i < RNG.RandomInt(0, _maxInitialWeapons); i++)
            {
                initialWeapons.Add(GameFactory.Instance().WeaponFactory.CreateWeapon());
            }
            return initialWeapons;
        }

        public virtual double DealDamage()
        {
            double bestWeaponDamage = WeaponsOwned.Count == 0 ? 0 : WeaponsOwned.Select(w => w.MaxWeaponDamage).Max();
            double bestDamage = bestWeaponDamage > _meleeMaxDamage ? bestWeaponDamage : _meleeMaxDamage;
            return RNG.RandomDouble(0.0, bestDamage);
        }

        public virtual void ReceiveDamage(double damagePoints)
        {
            HealthPoints = HealthPoints - damagePoints;
        }

        public virtual void AddArmor(IArmor armor)
        {
            ArmorOwned.Add(armor);
        }

        public virtual void AddWeapon(IWeapon weapon)
        {
            WeaponsOwned.Add(weapon);
        }

        public virtual void ClearItems()
        {
            ArmorOwned.Clear();
            WeaponsOwned.Clear();
        }

        public override string ToString()
        {
            string desc = $"{Name} has {GoldOwned} gold, " +
                          $"has {HealthPoints:F1} health points, " + 
                          $"and has {ArmorPoints:F1} armor points\n";
            desc += $"{Name} owns {ArmorOwned.Count} armor items:\n";
            foreach (var v in ArmorOwned)
            {
                desc += $"{v}\n";
            }
            desc += $"{Name} owns {WeaponsOwned.Count} weapon items:\n";
            foreach (var v in WeaponsOwned)
            {
                desc += $"{v}\n";
            }

            return desc;
        }
        #endregion
    }
}