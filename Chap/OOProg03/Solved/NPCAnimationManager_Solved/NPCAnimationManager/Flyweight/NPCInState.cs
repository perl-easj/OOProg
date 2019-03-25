using NPCAnimationManager.Common.Animation;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Flyweight
{
    /// <summary>
    /// Class representing the INtrinsic state of an NPC, i.e.
    /// the part of the state which is sharable among Flyweights.
    /// </summary>
    public class NPCInState
    {
        public int[] AnimationData { get; }

        public NPCInState(NPCType npcType)
        {
            AnimationData = AnimationDataDB.GetAnimationData(npcType);
        }
    }
}