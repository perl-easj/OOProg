using NPCAnimationManager.Common.Helpers;
using NPCAnimationManager.Common.Types;

namespace NPCAnimationManager.Flyweight
{
    /// <summary>
    /// Class representing the EXtrinsic state of an NPC, i.e.
    /// the part of the state which should be passed to the
    /// Flyweight when an operation needs to be invoked.
    /// </summary>
    public class NPCExState
    {
        #region Instance fields
        public int ID { get; }
        public NPCType TypeOfNPC { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public NPCState CurrentState { get; set; }
        #endregion

        #region Constructor
        public NPCExState(NPCType npcType)
        {
            ID = NPCGeneratorHelper.NextID;
            TypeOfNPC = npcType;

            CurrentState = NPCState.idle;
            X = 0;
            Y = 0;
        }
        #endregion
    }
}