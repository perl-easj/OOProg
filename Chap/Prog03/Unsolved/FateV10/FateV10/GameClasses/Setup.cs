using System;
using System.Collections.Generic;
using System.Linq;
using FateV10.GearClasses;

namespace FateV10.GameClasses
{
    /// <summary>
    /// This class contains setup information for the game.
    /// </summary>
    public class Setup
    {
        // Minimal and maximal PowerLevel for items
        public const int MinPowerLevel = 100;
        public const int MaxPowerLevel = 1000;

        // Convenient list of all Gear slots
        public static List<GearSlot> GearSlots
        {
            get { return Enum.GetValues(typeof(GearSlot)).Cast<GearSlot>().ToList(); }
        }

        // Convenient list of all Affinity types
        public static List<AffinityType> AffinityTypes
        {
            get { return Enum.GetValues(typeof(AffinityType)).Cast<AffinityType>().ToList(); }
        }

        // Weight factors for Gear conrtibution to PowerLevel (not used yet)
        public static Dictionary<GearSlot, int> GearContributionWeight;

        #region Constructor
        public Setup()
        {
            GearContributionWeight = new Dictionary<GearSlot, int>();

            GearContributionWeight.Add(GearSlot.Head, 20);
            GearContributionWeight.Add(GearSlot.Chest, 20);
            GearContributionWeight.Add(GearSlot.Hands, 10);
            GearContributionWeight.Add(GearSlot.Legs, 10);
            GearContributionWeight.Add(GearSlot.Feet, 10);
            GearContributionWeight.Add(GearSlot.LeftHand, 15);
            GearContributionWeight.Add(GearSlot.RightHand, 15);

            if (GearContributionWeight.Values.Sum() != 100)
            {
                throw new ArgumentException("Setup: GearContributionWeight do not add up to 100 %");
            }
        } 
        #endregion
    }
}