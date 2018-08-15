using System;

namespace WeaponShopV20
{
    /// <summary>
    /// This class is intended to be a base class for
    /// all classes representing a specific weapon.
    /// </summary>
    public class Weapon
    {
        #region Instance fields
        private string _description;
        private int _minDamage;
        private int _maxDamage;
        #endregion

        #region Constructor
        public Weapon(string description, int minDamage, int maxDamage)
        {
            _description = description;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the description of the weapon.
        /// Cannot be changed after construction.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }

        /// <summary>
        /// Returns the minimum damage dealt by the weapon.
        /// Derived classes can read and change this value.
        /// </summary>
        protected int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        /// <summary>
        /// Returns the maximum damage dealt by the weapon.
        /// Derived classes can read and change this value.
        /// </summary>
        protected int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculate the damage dealt by the weapon. 
        /// Since the calculation uses random numbers, 
        /// it will not return the same value every time.
        /// </summary>
        public virtual int DealDamage()
        {
            return RandomNumber(MinDamage, MaxDamage);
        } 
        #endregion

        #region Helper method for random number generation
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        private int RandomNumber(int lowerLimit, int upperLimit)
        {
            return _rng.Next(lowerLimit, upperLimit + 1);
        }
        #endregion
    }
}