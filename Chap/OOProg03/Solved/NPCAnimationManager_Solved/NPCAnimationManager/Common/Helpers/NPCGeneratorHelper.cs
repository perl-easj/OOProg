using System;
using System.Collections.Generic;
using System.Linq;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Common.Helpers
{
    /// <summary>
    /// This class contains a couple of helper
    /// functionalities for NPC generation.
    /// </summary>
    public class NPCGeneratorHelper
    {
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        private static int _nextId = 1;

        public static int NextID
        {
            get { return _nextId++; }
        }

        /// <summary>
        /// Just a touch of grey magic to generate a random NPC type.
        /// </summary>
        public static NPCType GenerateRandomNPCType()
        {
            List<NPCType> npcTypes = Enum.GetValues(typeof(NPCType)).Cast<NPCType>().ToList();
            return npcTypes[_rng.Next(npcTypes.Count)];
        }
    }
}