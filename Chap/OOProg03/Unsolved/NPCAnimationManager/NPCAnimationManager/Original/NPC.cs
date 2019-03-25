using NPCAnimationManager.Common.Animation;
using NPCAnimationManager.Common.Helpers;
using NPCAnimationManager.Common.Interfaces;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Original
{
    /// <summary>
    /// Traditional implementation of an NPC. The class
    /// implements the INPC imterface.
    /// </summary>
    public class NPC : INPC
    {
        #region Instance fields
        public int ID { get; }
        public NPCType TypeOfNPC { get; }
        public NPCState CurrentState { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int[] AnimationData { get; private set; }
        #endregion

        #region Constructor
        public NPC(NPCType npcType)
        {
            ID = NPCGeneratorHelper.NextID;
            TypeOfNPC = npcType;
            CurrentState = NPCState.idle;            
            X = 0;
            Y = 0;

            // Animation data is fetched from the (simulated) database.
            AnimationData = AnimationDataDB.GetAnimationData(npcType);

        }
        #endregion

        /// <summary>
        /// Performs the (simulated) animation of the NPC.
        /// </summary>
        public void Animate()
        {
            AnimationHandler.PerformAnimation(X, Y, CurrentState, AnimationData);
        }
    }
}