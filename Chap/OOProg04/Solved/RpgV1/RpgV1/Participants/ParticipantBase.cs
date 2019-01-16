using System;
using System.Collections;
using System.Collections.Generic;
using RpgV1.Spells;

namespace RpgV1.Participants
{
    /// <summary>
    /// Base class for all participants in the game world.
    /// [ADDED]: Did NOT originally inherit from IEnumerable.
    /// </summary>
    public abstract class ParticipantBase : IParticipant, IEnumerable<Tuple<SpellType, double>>
    {
        #region Properties
        public string Name { get; }
        public int Level { get; }
        public Dictionary<SpellType, double> SpellVector { get; }
        public abstract double NotPresentValue { get; }
        public abstract double Modifier { get; }
        #endregion

        #region Constructor
        protected ParticipantBase(string name, int level)
        {
            Name = name;
            Level = level;
            SpellVector = new Dictionary<SpellType, double>();
        }
        #endregion

        #region [ADDED] Index operator
        /// <summary>
        /// Indexing is done with spell type as index key.
        /// </summary>
        /// <param name="st">A spell type</param>
        /// <returns>
        /// Corresponding value for spell type (or default value),
        /// NOT modified by the Modifier value!
        /// </returns>
        public double this[SpellType st]
        {
            get { return SpellVector.ContainsKey(st) ? SpellVector[st] : NotPresentValue; }
            set { SpellVector[st] = value; }
        }
        #endregion

        #region [ADDED] IEnumerable implementation
        /// <summary>
        /// The Enumerator will - for each spell type - return a Tuple with two values:
        /// 1) The spell type itself
        /// 2) The corresponding effective value, i.e. the raw value multiplied with the modifier
        /// </summary>
        public IEnumerator<Tuple<SpellType, double>> GetEnumerator()
        {
            foreach (SpellType st in Spell.SpellTypeList)
            {
                yield return new Tuple<SpellType, double>(st, this[st] * Modifier);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
        #endregion
    }
}