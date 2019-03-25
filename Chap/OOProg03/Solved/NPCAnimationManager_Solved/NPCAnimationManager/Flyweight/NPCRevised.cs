using NPCAnimationManager.Common.Animation;
using NPCAnimationManager.Common.Interfaces;

namespace NPCAnimationManager.Flyweight
{
    /// <summary>
    /// A revised implementation of NPC, which is essentially
    /// a "wrapper" around an (individual) EXtrinsinc state
    /// and an (shared) INtrinsic state.
    /// Note that this class DOES implement INPC.
    /// </summary>
    public class NPCRevised : INPC
    {
        private NPCInState InState { get; }
        private NPCExState ExState { get; }

        public NPCRevised(NPCInState inState, NPCExState exState)
        {
            InState = inState;
            ExState = exState;
        }

        public void Animate()
        {
            AnimationHandler.PerformAnimation(
                ExState.X, ExState.Y, ExState.CurrentState, 
                InState.AnimationData);
        }
    }
}