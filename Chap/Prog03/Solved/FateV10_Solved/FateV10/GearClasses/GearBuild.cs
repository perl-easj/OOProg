using System.Collections.Generic;
using System.Linq;
using FateV10.GameClasses;

namespace FateV10.GearClasses
{
    /// <summary>
    /// A GearBuild is a set of Gear objects, such that no two Gear objects
    /// have the same GearSlot value. A Hero will thus be able to equip all
    /// Gear items in such a build.
    /// </summary>
    public class GearBuild
    {
        #region Instance fields and Constructor
        private Dictionary<GearSlot, Gear> _gear;

        public GearBuild()
        {
            _gear = new Dictionary<GearSlot, Gear>();

            // Initially, all Gear slots are empty.
            foreach (GearSlot slot in Setup.GearSlots)
            {
                _gear.Add(slot, null);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// The PowerLevel of a GearBuild is calculated as the average of all the
        /// Gear objects currently included in the build. Note that the average is
        /// calculated such that an empty slot contributes to the average with a
        /// value of 0 (zero).
        /// </summary>
        public int PowerLevel
        {
            get { return _gear.Values.ToList().Sum(g => g.PowerLevel) / _gear.Count; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// This method will place the given Gear object into the correct Gear slot.
        /// This is done unconditionally, i.e. no matter if the slot is already filled.
        /// </summary>
        public GearBuild AddGear(Gear gear)
        {
            _gear[gear.Slot] = gear;
            return this;
        }

        /// <summary>
        /// Creates a string containing a summary of the gear build.
        /// Note the use of the Aggregate method...
        /// </summary>
        public override string ToString()
        {
            return _gear.Aggregate(
                "",
                (s, pair) => s + $"\n{pair.Key} :  {pair.Value}",
                s => $"Gear in Gear Build (Power Level {PowerLevel}):" + s);
        } 
        #endregion
    }
}