using System;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Common.Animation
{
    /// <summary>
    /// Class simulating a database from which animation data packages
    /// can be extracted. It is assumed that one such package exist for
    /// each NPC type. The package will contain data for animating the
    /// NPC in all valid states.
    /// </summary>
    public class AnimationDataDB
    {
        private const int AnimationDataSize = 25000;
        private static Random _rng = null;

        /// <summary>
        /// Returns a large chunk of data, which simulates
        /// actual animation data for the given NPC type.
        /// </summary>
        public static int[] GetAnimationData(NPCType npcType)
        {
            _rng = new Random((int)npcType);

            int[] data = new int[AnimationDataSize];
            for (int i = 0; i < AnimationDataSize; i++)
            {
                data[i] = _rng.Next();
            }

            return data;
        }
    }
}