using System;

namespace RpgV1.Participants
{
    /// <summary>
    /// Class modeling an player, i.e. a being that can engage in combat
    /// against an Opponent, either alone or in a group with other players.
    /// For a Player, the SpellVector signifies the DPS (Damage Per Second),
    /// the player deals of this type of magic.
    /// If the SpellVector e.g. contains the value (lavaFlow, 30), the
    /// interpretation is that the player deals 30 DPS of spell damage for
    /// this kind of spell. Furthermore, the damage output is amplified by
    /// by the value of the Modifier (see below).
    /// Effective damage dealt for a spell type is thus:
    /// Effective damage = Raw damage x modifier.
    /// </summary>
    public class Player : ParticipantBase
    {
        #region Properties
        /// <summary>
        /// For a Player, the absence of a value for a spell type is
        /// interpreted as 0 (zero), i.e. the player cannot deal damage
        /// of this spell type.
        /// </summary>
        public override double NotPresentValue
        {
            get { return 0.0; }
        }

        /// <summary>
        /// For an Player, the Modifier scales with Level, i.e. the
        /// higher the level, the higher the damage dealt.
        /// </summary>
        public override double Modifier
        {
            get { return Math.Sqrt(Level); }
        }
        #endregion

        #region Constructor
        public Player(string name, int level) : base(name, level)
        {
        }
        #endregion
    }
}