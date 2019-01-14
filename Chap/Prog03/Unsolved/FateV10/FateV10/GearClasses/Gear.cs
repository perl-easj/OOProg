using System;
using FateV10.GameClasses;

namespace FateV10.GearClasses
{
    /// <summary>
    /// Gear is used as a common denominator for all types of equipment
    /// a Hero can own and use. This may be "armor" or "weapon", but we
    /// only differentiate the purpose of a piece of Gear by its "slot".
    /// 
    /// A piece of Gear has these properties:
    /// 1) Slot: Where does the Gear fit (i.e. hands, feet, etc.)
    /// 2) PowerLevel: Expresses the "power" of the Gear. The higher
    /// the PowerLevel, the better the Gear. 
    /// 3) Affinity: The world has three kinds of "affinity":
    /// Sun, Moon and Stars. The idea is certain places
    /// (e.g. dungeons) have an "affinity". If e.g. a Dungeon has
    /// the Moon affinity, you can ONLY use Gear with Moon affinity
    /// in that particular Dungeon.
    /// 4) Description: A description of the Gear, which does not
    /// have any functional significance.
    /// </summary>
    public class Gear : IComparable<Gear>
    {
        #region Properties
        public GearSlot Slot { get; }
        public int PowerLevel { get; }
        public AffinityType Affinity { get; }
        public string Description { get; }
        #endregion

        #region Constructor
        public Gear(GearSlot slot, int powerLevel, AffinityType affinity, string description)
        {
            Slot = slot;
            PowerLevel = powerLevel;
            Description = description;
            Affinity = affinity;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Note that Gear implements IComparable, such that Gear objects
        /// can be compared (according to PowerLevel).
        /// </summary>
        public int CompareTo(Gear other)
        {
            return PowerLevel - other.PowerLevel;
        }

        public override string ToString()
        {
            return $"{Description}  [{Slot}, {Affinity}]  (power level {PowerLevel})";
        } 
        #endregion
    }
}