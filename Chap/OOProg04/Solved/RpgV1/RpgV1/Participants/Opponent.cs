using System;

namespace RpgV1.Participants
{
    /// <summary>
    /// Class modeling an opponent, i.e. a being that one or more Players
    /// can engage in combat. For an Opponent, the SpellVector signifies
    /// the "vunerability" of the opponent for certain type of spell.
    /// If the SpellVector e.g. contains the value (iceStorm, 20), the
    /// interpretation is that 20 % of the spell damage of this kind dealt
    /// to the opponent is "effective", i.e. lowers the health of the opponent.
    /// If e.g. 250 DPS of iceStorm damage is dealt, the opponent only suffers
    /// 20 % x 250 = 50 DPS of net damage for this spell type. Furthermore,
    /// the damage is also mitigated by the value of the Modifier (see below).
    /// Effective damage suffered for a spell type is thus:
    /// Effective damage = Raw damage x vunerability x modifier.
    /// </summary>
    public class Opponent : ParticipantBase
    {
        #region Properties
        /// <summary>
        /// For an Opponent, the absence of a value for a spell type is
        /// interpreted as 100.0 (zero), i.e. the opponent is fully
        /// vunerable for damage of this spell type.
        /// </summary>
        public override double NotPresentValue
        {
            get { return 100.0; }
        }

        /// <summary>
        /// For an Opponent, the Modifier scales inversely with Level, i.e. the
        /// higher the level, the less damage suffered.
        /// </summary>
        public override double Modifier
        {
            get { return 1.0 / Math.Pow(Level, 0.3); }
        }
        #endregion

        #region Constructor
        public Opponent(string name, int level) : base(name, level)
        {
        } 
        #endregion
    }
}