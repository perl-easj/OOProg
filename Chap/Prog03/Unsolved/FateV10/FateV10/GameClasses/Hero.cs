using System;
using System.Collections.Generic;
using System.Linq;
using FateV10.GearClasses;

namespace FateV10.GameClasses
{
    /// <summary>
    /// A Hero is a character in this imaginary game world.
    /// A Hero can OWN as many pieces of Gear as (s)he wishes,
    /// but can only EQUIP one piece of Gear in each gear slot
    /// at any time.
    /// </summary>
    public class Hero
    {
        #region Instance fields, Properties and Constructor
        private Dictionary<GearSlot, List<Gear>> _gearOwned;

        public string Name { get; }

        public Hero(string name)
        {
            Name = name;
            _gearOwned = new Dictionary<GearSlot, List<Gear>>();
        }
        #endregion

        #region Main public methods
        /// <summary>
        /// Adds one piece of Gear to the inventory of Gear
        /// owned by the Hero.
        /// </summary>
        public Hero AddGear(Gear gear)
        {
            if (!_gearOwned.ContainsKey(gear.Slot))
            {
                _gearOwned.Add(gear.Slot, new List<Gear>());
            }

            _gearOwned[gear.Slot].Add(gear);
            return this;
        }

        /// <summary>
        /// Creates a string containing a summary of the Hero.
        /// Could you do this in a nicer way using Aggregate?
        /// </summary>
        public override string ToString()
        {
            string desc = $"The Hero {Name}";

            desc += $"\nPower Level         : {PowerLevel()}";
            foreach (AffinityType affType in Setup.AffinityTypes)
            {
                desc += $"\nPower Level [{affType.ToString().PadRight(6)}]   : {PowerLevel(affType)}";
            }

            desc += "\n\nGear owned";
            foreach (var entry in _gearOwned)
            {
                desc += $"\n{entry.Key}  ({entry.Value.Count} items) ";

                foreach (var gear in entry.Value)
                {
                    desc += $"\n{gear}";
                }

                desc += $"\nBest          :  {BestGearInSlot(entry.Key)}";

                foreach (AffinityType affType in Setup.AffinityTypes)
                {
                    desc += $"\nBest [{affType.ToString().PadRight(6)}]    :  {BestGearInSlot(entry.Key, affType)}";
                }
            }

            return desc;
        }

        /// <summary>
        /// Given an Affinity, return a list of Gear objects, such that:
        /// 1) The list contains at most one Gear object for each Gear slot.
        /// 2) A Gear object in the list will be the "best" Gear object for
        ///    that particular gear slot, for given affinity.
        /// In short, the list should define the best possible set of Gear
        /// for the hero, for the given Affinity.
        /// </summary>
        public List<Gear> BestGear(AffinityType affinity)
        {
            return new List<Gear>(); // TODO - Implement correctly
        }

        /// <summary>
        /// Given an Affinity, return the optimal GearBuild for the Hero
        /// for that affinity.
        /// </summary>
        public GearBuild BestGearBuild(AffinityType affinity)
        {
            return null; // TODO - Implement correctly
        }
        #endregion

        #region Helper methods (PowerLevel calculation)
        /// <summary>
        /// Calculate the PowerLevel for the Hero, defined as follows:
        /// 1) For each Gear slot, select the best Gear object owned by the Hero,
        ///    subjected to the selection criterion provided by the selector parameter.
        /// 2) Calculate the sum of PowerLevels for all Gear objects found in 1)
        /// 3) Divide the number from 2) with the number of Gear slots.
        /// </summary>
        public int PowerLevel(Func<Gear, bool> selector)
        {
            return 0; // TODO - Implement correctly
        }

        /// <summary>
        /// Convenient parameterless version of PowerLevel,
        /// i.e. no restrictions on Gear selection.
        /// </summary>
        public int PowerLevel()
        {
            return PowerLevel(g => true);
        }

        /// <summary>
        /// Version of PowerLevel with Affinity as parameter.
        /// Will thus return the (optimal) PowerLevel for the Hero,
        /// for this specific affinity.
        /// </summary>
        public int PowerLevel(AffinityType affinity)
        {
            return PowerLevel(g => g.Affinity == affinity);
        }

        /// <summary>
        /// Simply converts an "empty" gear slot to a
        /// PowerLevel value of 0 (zero).
        /// </summary>
        public int GearToPowerLevel(Gear gear)
        {
            return gear?.PowerLevel ?? 0;
        }
        #endregion

        #region Helper methods (best-in-slot Gear calculation)
        /// <summary>
        /// Selects the best-in-slot Gear object for the Hero, subjected to the
        /// selection criterion provided by the selector parameter.
        /// </summary>
        public Gear BestGearInSlot(GearSlot slot, Func<Gear, bool> selector)
        {
            return null; // TODO - Implement correctly
        }

        /// <summary>
        /// Selects the best-in-slot Gear object for the Hero, without restrictions.
        /// </summary>
        public Gear BestGearInSlot(GearSlot slot)
        {
            return BestGearInSlot(slot, g => true);
        }

        /// <summary>
        /// Selects the best-in-slot Gear object for the Hero, for the given Affinity.
        /// </summary>
        public Gear BestGearInSlot(GearSlot slot, AffinityType affinity)
        {
            return BestGearInSlot(slot, g => g.Affinity == affinity);
        } 
        #endregion
    }
}