using System;
using System.Collections.Generic;
using FateV10.GearClasses;

namespace FateV10.GameClasses
{
    /// <summary>
    /// This class is just a helper class for the author of this project, to make it
    /// easier (and more fun) to generate Gear objects. You do NOT need to investigate
    /// this class futher (but of course feel free to do so anyway :-)).
    /// </summary>
    public class GearGenerator
    {
        #region Instance fields and Constructor
        private Random _rng;

        /// <summary>
        /// If you want a different set of Gear to be generated,
        /// simply provide a different seed value.
        /// </summary>
        public GearGenerator(int seed = 42)
        {
            _rng = new Random(seed);
        }
        #endregion

        #region Static Lists with Gear generation information
        private static List<GearSlot> _gearSlots = new List<GearSlot>
        {
            GearSlot.Head,
            GearSlot.Chest,
            GearSlot.Hands,
            GearSlot.Legs,
            GearSlot.Feet,
            GearSlot.LeftHand,
            GearSlot.RightHand
        };

        private static List<AffinityType> _affinityTypes = new List<AffinityType>
        {
            AffinityType.Moon,
            AffinityType.Sun,
            AffinityType.Stars
        };

        private static Dictionary<GearSlot, List<string>> _gearSynonymes = new Dictionary<GearSlot, List<string>>
        {
            {GearSlot.Head, new List<string> {"Helm", "Hood", "Crown", "Cowl", "Car"}},
            {GearSlot.Chest, new List<string> {"Chestplate", "Vestments", "Robe", "Tunic"}},
            {GearSlot.Hands, new List<string> {"Gloves", "Handwraps", "Handguards", "Fistbands"}},
            {GearSlot.Legs, new List<string> {"Leggings", "Pants", "Trousers", "Britches", "Kilt"}},
            {GearSlot.Feet, new List<string> {"Shoes", "Boots", "Sandals", "Footwraps", "Kickers", "Treads"}},
            {GearSlot.LeftHand, new List<string> {"Sword", "Dagger", "Mace", "Stick", "Knife", "Whip"}},
            {GearSlot.RightHand, new List<string> {"Sword", "Dagger", "Mace", "Stick", "Knife", "Whip"}},
        };

        private static Dictionary<AffinityType, List<string>> _gearAssociasions = new Dictionary<AffinityType, List<string>>
        {
            {AffinityType.Sun, new List<string> {"Warmth", "Sunshine", "Brightness", "Radiance", "Golden Ages"}},
            {AffinityType.Moon, new List<string> {"Silver", "Shadows", "The New Moon", "The Phases"}},
            {AffinityType.Stars, new List<string> {"The Endless", "The Veil", "Constellations", "Stellar Dreams", "Infinity"}}
        };
        #endregion

        #region Public methods
        public Gear Generate()
        {
            GearSlot slot = GenerateGearSlot();
            AffinityType affinityType = GenerateAffinityType();
            int powerLevel = GeneratePowerLevel();

            string description = GenerateGearDescription(slot, affinityType, powerLevel);
            return new Gear(slot, powerLevel, affinityType, description);
        } 
        #endregion

        #region Private helper methods
        private int GeneratePowerLevel()
        {
            return _rng.Next(100, 1000);
        }

        private GearSlot GenerateGearSlot()
        {
            return _gearSlots[_rng.Next(0, _gearSlots.Count)];
        }

        private AffinityType GenerateAffinityType()
        {
            return _affinityTypes[_rng.Next(0, _affinityTypes.Count)];
        }

        private string GenerateGearDescription(GearSlot slot, AffinityType affinityType, int powerLevel)
        {
            string adjective = GenerateAdjective(powerLevel);
            string synonym = GenerateSynonym(slot);
            string associasion = GenerateAssociasion(affinityType);
            string spacing = adjective.Length > 0 ? " " : "";

            return adjective + spacing + synonym + " of " + associasion;
        }

        private string GenerateAdjective(int powerLevel)
        {
            double scaledPowerLevel = ((powerLevel - Setup.MinPowerLevel) * 1.0) /
                                      ((Setup.MaxPowerLevel - Setup.MinPowerLevel) * 1.0);

            if (scaledPowerLevel < 0.15) return "Weak";
            if (scaledPowerLevel < 0.35) return "Minor";
            if (scaledPowerLevel < 0.65) return "";
            if (scaledPowerLevel < 0.85) return "Strong";
            if (scaledPowerLevel < 1) return "Powerful";

            return "Amazing";
        }

        private string GenerateSynonym(GearSlot slot)
        {
            return _gearSynonymes[slot][_rng.Next(0, _gearSynonymes[slot].Count)];
        }

        private string GenerateAssociasion(AffinityType affinityType)
        {
            return _gearAssociasions[affinityType][_rng.Next(0, _gearAssociasions[affinityType].Count)];
        } 
        #endregion
    }
}