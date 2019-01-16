using System;
using RpgV1.Spells;

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

        #region [ADDED] Override of operator +
        /// <summary>
        /// This is the (slightly strange) logic for adding two Player objects.
        /// </summary>
        public static Player operator +(Player a, Player b)
        {
            // The resulting Player object has the neutral name "SumPlayer",
            // and is Level 1 (which will result in a Modifier with value 1).
            Player sumPlayer = new Player("SumPlayer", 1);

            // For each spell type, the DPS value is set to the sum of the
            // effective DPS value for both players.
            foreach (SpellType st in Spell.SpellTypeList)
            {
                sumPlayer[st] = (a[st] * a.Modifier) + (b[st] * b.Modifier);
            }

            return sumPlayer;
        }
        #endregion

        #region [ADDED] Override of operator *, with operands Player and Opponent
        public static double operator *(Player p, Opponent o)
        {
            double dps = 0;

            foreach (SpellType st in Spell.SpellTypeList)
            {
                dps += ((p[st] * p.Modifier) * (o[st] * o.Modifier)) / 100.0;
            }

            return dps;
        } 
        #endregion
    }
}