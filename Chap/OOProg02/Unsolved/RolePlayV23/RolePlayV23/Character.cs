namespace RolePlayV23
{
    /// <summary>
    /// This class represents a game character.
    /// </summary>
    public class Character
    {
        #region Instance fields
        private string _name;
        protected int _hitPoints;
        protected int _maxHitPoints;
        protected int _minDamage;
        protected int _maxDamage;
        #endregion

        #region Constructor
        public Character(string name, int hitPoints, int minDamage, int maxDamage)
        {
            _name = name;
            _maxHitPoints = hitPoints;
            _minDamage = minDamage;
            _maxDamage = maxDamage;
            Reset();
        }
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Checks if the Character is dead, defined as having 0 or less hit points...
        /// </summary>
        public bool Dead
        {
            get { return (_hitPoints <= 0); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reset the Character's state to the original state
        /// </summary>
        public void Reset()
        {
            _hitPoints = _maxHitPoints;
        }

        /// <summary>
        /// Returns the amount of points a Character deals in damage.
        /// This damage could then be received by another character.
        /// Note that there is a chance that the damage is modified.
        /// </summary>
        public int DealDamage()
        {
            int damage = NumberGenerator.Next(_minDamage, _maxDamage);
            int modifiedDamage = DealDamageModify(damage);

            string damageDescription = (damage < modifiedDamage) ? "(INCREASED)" : "";
            string message = $"{Name} dealt {modifiedDamage} damage {damageDescription}";

            BattleLog.Save(message);
            return modifiedDamage;
        }

        /// <summary>
        /// The Character receives the amount of damage specified in the parameter.
        /// The number of hit points will decrease accordingly.
        /// Note that there is a chance that the damage is modified.
        /// </summary>
        public void ReceiveDamage(int damage)
        {
            int modifiedDamage = ReceiveDamageModify(damage);
            _hitPoints = _hitPoints - modifiedDamage;

            string damageDescription = (damage > modifiedDamage) ? "(DECREASED)" : "";
            string message = $"{Name} receives {modifiedDamage} damage {damageDescription}, and is down to {_hitPoints} HP";

            BattleLog.Save(message);
            if (Dead)
            {
                BattleLog.Save(Name + " died!");
            }
        }

        /// <summary>
        /// Log data about the character to the battle log,
        /// in case the character is still alive.
        /// </summary>
        public void LogSurvivor()
        {
            if (!Dead)
            {
                BattleLog.Save(Name + " survived with " + _hitPoints + " hit points left");
            }
        }

        /// <summary>
        /// Modifies the amount of dealt damage. 
        /// </summary>
        private int DealDamageModify(int dealtDamage)
        {
            int modifiedDealtDamage = dealtDamage;
            if (NumberGenerator.BelowPercentage(DealDamageModifyChance))
            {
                modifiedDealtDamage = CalculateModifiedDealDamage(dealtDamage);
            }

            return modifiedDealtDamage;
        }

        /// <summary>
        /// Modifies the amount of received damage. 
        /// </summary>
        private int ReceiveDamageModify(int receivedDamage)
        {
            int modifiedReceivedDamage = receivedDamage;

            if (NumberGenerator.BelowPercentage(ReceiveDamageModifyChance))
            {
                modifiedReceivedDamage = CalculateModifiedReceivedDamage(receivedDamage);
            }

            return modifiedReceivedDamage;
        }
        #endregion

        #region Virtual Properties and Methods
        /// <summary>
        /// Returns the chance of the damage dealt being modified.
        /// Unless overrided in a derived class, a Character has
        /// 0 % chance of having the damage dealt modified.
        /// </summary>
        protected virtual int DealDamageModifyChance
        {
            get { return 0; }
        }

        /// <summary>
        /// Returns the chance of the damage received being modified.
        /// Unless overrided in a derived class, a Character has
        /// 0 % chance of having the damage Received modified.
        /// </summary>
        protected virtual int ReceiveDamageModifyChance
        {
            get { return 0; }
        }

        /// <summary>
        /// Returns the modified dealt damage.
        /// Unless overrided in a derived class, the modified dealt 
        /// damage is the same as the original dealt damage.
        /// </summary>
        protected virtual int CalculateModifiedDealDamage(int dealtDamage)
        {
            return dealtDamage;
        }

        /// <summary>
        /// Returns the modified received damage.
        /// Unless overrided in a derived class, the modified received 
        /// damage is the same as the original received damage.
        /// </summary>
        protected virtual int CalculateModifiedReceivedDamage(int receivedDamage)
        {
            return receivedDamage;
        }
        #endregion
    }
}
