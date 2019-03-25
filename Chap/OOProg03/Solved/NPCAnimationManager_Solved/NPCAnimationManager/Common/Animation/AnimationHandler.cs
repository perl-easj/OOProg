using System;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Common.Animation
{
    /// <summary>
    /// Class simulating actual animation of an NPC.
    /// </summary>
    public class AnimationHandler
    {
        /// <summary>
        /// Simulates an animation of an NPC in the given state.
        /// We assume that the animation data for animating the NPC
        /// in the given state can be extracted from the data
        /// provided in the animationData argument.
        /// </summary>
        public static void PerformAnimation(
            double x, double y, 
            NPCState npcState, 
            int[] animationData)
        {
            if (animationData == null) throw new ArgumentException(
                "Tried to call PerformAnimation without animation data");
        }
    }
}